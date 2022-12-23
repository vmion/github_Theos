using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_teleport : MonoBehaviour
{
    public Transform Teleport_Out;
    Vector3 warp;
    void Start()
    {
        warp = new Vector3(-5, 0, 0);
    }
    void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag.Equals("Player"))
        {
            _col.gameObject.transform.position = Teleport_Out.transform.position;
            _col.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            Debug.Log("Trigger");
        }
    }
    void Update()
    { 
    }
}
