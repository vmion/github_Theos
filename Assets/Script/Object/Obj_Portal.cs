using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Portal : MonoBehaviour
{    
    public GameObject caution;
    public static bool CamX = false;
    void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag.Equals("Player"))
        {            
            caution.gameObject.SetActive(true);
            Time.timeScale = 0f;
            CamX = true;
        }
    }    
}
