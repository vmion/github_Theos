using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bounds : MonoBehaviour
{
    public static Collider mobCollider { get; set; }
    Collider otherCollider;
    GameObject mob;
    void Awake()
    {
        mobCollider = GetComponentInChildren<Collider>();
        //otherCollider = Character_Manager.playerCollider;        
    }
    void Start()
    {        
        Debug.Log(mobCollider.gameObject.name);
    }
    void Update()
    {
        if(mobCollider.bounds.Intersects(otherCollider.bounds))
        {
            //mob.SetActive(false);
        }
    }
}
