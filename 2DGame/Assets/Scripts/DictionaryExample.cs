using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    // Dictionary 선언
    Dictionary<int, string> dicPlayer = new Dictionary<int, string>();
    
    void Start()
    {
        dicPlayer.Add(1, "Player1");
        dicPlayer.Add(2, "Player2");

        foreach (var player in dicPlayer)
        {
            Debug.Log($"Key {player.Key} Value {player.Value}");
        }
    }
}
