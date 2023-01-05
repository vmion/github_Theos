using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Login : MonoBehaviour
{
    public Transform ParentPlayer;    
    void Start()
    {
        Invoke("LogIN", 1f);
    }
    void LogIN()
    {
        GameObject player = Instantiate(Character_Manager.charDic["플레이어"], ParentPlayer);
        player.tag = "Player";
        player.transform.position = new Vector3(-15f, 0, 0);               
    }
    void Update()
    {
        
    }
}
