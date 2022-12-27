using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Panel : MonoBehaviour
{    
    BoxCollider collider;
    public GameObject panel;    
    public BoxCollider Char;
    public bool COLLISIONCHECK { get; set; }
    void Awake()
    {
        collider = GetComponent<BoxCollider>();
        COLLISIONCHECK = true;
    }

    void Update()
    {
        if(COLLISIONCHECK)
        {
            if(collider.bounds.Intersects(Char.bounds))
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }        
    }
}
