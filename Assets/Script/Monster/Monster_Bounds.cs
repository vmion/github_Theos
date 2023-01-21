using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bounds : MonoBehaviour
{
    public static Collider mobCollider { get; set; }
    Collider PlayerCollider;    
    void Awake()
    {
        mobCollider = GetComponent<Collider>();
        PlayerCollider = Character_Manager.playerCollider;        
    }
    void Start()
    {
        
        Debug.Log(mobCollider.gameObject.name);
        Debug.Log(PlayerCollider.gameObject.name);
    }    
    void Update()
    {     
        if(mobCollider.bounds.Intersects(PlayerCollider.bounds))
        {
            mobCollider.gameObject.SetActive(false);
        }        
    }
}
