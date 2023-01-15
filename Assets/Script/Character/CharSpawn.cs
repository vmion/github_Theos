using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharSpawn : MonoBehaviour
{
    string sceneName;
    Scene nowScene;    
    void Awake()
    {
        nowScene = SceneManager.GetActiveScene();
        sceneName = nowScene.name;
    }
    void Start()
    {        
        if (sceneName == "_01_Village")
        {                      
            Character_Manager.instance.transform.position = transform.position;            
        }
        else if (sceneName == "_02_Forest")
        {            
            Character_Manager.instance.transform.localPosition = transform.position;
        }
        else if (sceneName == "_03_Labyrinth")
        {           
            Character_Manager.instance.transform.localPosition = transform.position;
        }
    }
    void Update()
    {
        
    }
}
