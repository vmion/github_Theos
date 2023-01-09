using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpawn : MonoBehaviour
{
    void Start()
    {
        if (Application.CanStreamedLevelBeLoaded(2))
        {
            Character_Manager.ParentPlayer.transform.position = new Vector3(-15f, 1f, 0f);
        }
        else if (Application.CanStreamedLevelBeLoaded(3))
        {
            Character_Manager.ParentPlayer.transform.position = new Vector3(-60f, 1f, -20f);
        }
        else if(Application.CanStreamedLevelBeLoaded(4))
        {
            Character_Manager.ParentPlayer.transform.position = new Vector3(45f, 1f, 45f);            
        }
    }
}
