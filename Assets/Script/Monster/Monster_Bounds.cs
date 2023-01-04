using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bounds : MonoBehaviour
{
    public Collider mobCollider { get; set; }
    public Collider otherCollider { get; set; }
    void Awake()
    {
        mobCollider = GetComponent<Collider>();
        otherCollider = Character_Manager.instance.GetComponent<Collider>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(mobCollider.bounds.Intersects(otherCollider.bounds))
        {

        }
    }
}
