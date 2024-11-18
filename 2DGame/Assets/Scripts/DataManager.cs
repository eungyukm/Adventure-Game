using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하기 위한 코드
    // 싱글톤은 단 하나만 존재해야 하는 클래스가 있을 때 만드는 디자인 패턴 입니다.
    // DataManager는 모든 데이터를 관리합니다.
    // 메모리에 상주
    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                // FindObjectOfType은 Scene 내에 존재하는
                // 모든 GameObject를 검색해서 <T> 타입의 컴포넌트를 찾아 반환합니다.
                instance = FindObjectOfType<DataManager>();
            }
            return instance;
        }
    }

    public int Day = 0;

    public void AddDay()
    {
        Day++;
    }

    public int GetDay()
    {
        return Day;
    }
    
    
    // 게임을 처음 시작했을 때 1회 호출되는 함수
    private void Awake()
    {
        // 씬이 변경되어도 삭제되지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

    public void Print()
    {
        Debug.Log("[DataManager]");
    }
    
    void Start()
    {
        // Datas/PlayerDogs json로드
        // Resources 폴더는 특수한 폴더입니다.
        // 런타임 에셋로드를 할 수 있습니다.
        // path를 명시할 때는 .json과 같은 확장자는 사용하지 않습니다.
        string json = Resources.Load<TextAsset>("Datas/PlayerDogs").text;
        Debug.Log(json);
        
        // 역직렬화
        // List는 크기를 지정할 수 없는 배열을 만들 때 사용합니다.
        // 배열은 지정된 크기를 넘어서면, 오류가 발생합니다.
        // int[100] 0 ~ 99 -> 100 error
        // List<int> intList = new List<int>();
        // intList.add(1);
        var playerDogs = JsonConvert.DeserializeObject<List<PlayerDogs>>(json);
        foreach (PlayerDogs playerDog in playerDogs)
        {
            Debug.Log(playerDog.player_number);
            Debug.Log(playerDog.dog_name);
            Debug.Log(playerDog.dog_image_path);
            Debug.Log(playerDog.dog_power);
        }
    }

    
    void Update()
    {
        
    }
}
