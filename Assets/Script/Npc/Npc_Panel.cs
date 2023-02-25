using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Panel : MonoBehaviour
{    
    Collider NpcCollider;
    public GameObject panel;    
    Collider Player;
    public Text panelName;
      
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
            panelName.text = " " + NpcCollider.name;
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
