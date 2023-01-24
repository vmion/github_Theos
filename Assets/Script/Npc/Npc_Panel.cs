using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Panel : MonoBehaviour
{    
    Collider NpcCollider;
    public GameObject panel;    
    Collider Player;
    public bool COLLISIONCHECK { get; set; }    
    void Start()
    {
        NpcCollider = GetComponent<Collider>();
        Player = Character_Manager.playerCollider;
        COLLISIONCHECK = true;
    }
    void Update()
    {
        if (COLLISIONCHECK)
        {
            if (NpcCollider.bounds.Intersects(Player.bounds))
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
