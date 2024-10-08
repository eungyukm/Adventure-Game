using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public InputAction moveAction;
    
    private void Start()
    {
        moveAction.Enable();
    }
    
    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Debug.Log(input);
        
        if (input.x != 0 || input.y != 0)
        {
            Vector3 movement = new Vector3(input.x, input.y, 0);
            Vector3 direction = movement.normalized;
            Debug.Log($"direction: {direction}");
            transform.position += direction * Time.deltaTime * speed;
        }
    }
}
