using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Panel : MonoBehaviour
{    
    Collider NpcCollider;
    public GameObject panel;    
    Collider Player;
      
    void Start()
    {
        NpcCollider = GetComponent<Collider>();
        Player = Character_Manager.playerCollider;             
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
    void Update()
    {
        /*
        if (NpcCollider.bounds.Intersects(Player.bounds))
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
        */
    }    
}
