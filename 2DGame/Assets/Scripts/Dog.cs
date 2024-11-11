using UnityEngine;
using UnityEngine.InputSystem;

public class Dog : MonoBehaviour
{
    public InputAction moveAction;
    public float speed = 4;
    // 외부에서 게임오브젝트를 받기 위해 선언한 변수입니다.
    public GameObject bad;
    
    void Start()
    {
        moveAction.Enable();
    }
    
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        if (move.x != 0 || move.y != 0)
        {
            Vector3 movement = new Vector3(move.x, move.y, 0);
            Vector3 direction = movement.normalized;
            transform.position += direction * Time.deltaTime * speed;
            
            DataManager.Instance.Print();
            int day = DataManager.Instance.GetDay();
            Debug.Log("Day: " + day);
        }
        
        float distance = Vector3.Distance(bad.transform.position, transform.position);

        if (distance < 1.0f)
        {
            DataManager.Instance.AddDay();
        }
    }
    
    
}
