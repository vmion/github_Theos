using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bounds : MonoBehaviour
{
    Collider mobCollider;
    Collider otherCollider;
    void Awake()
    {
        mobCollider = MonsterManager.monsterCollider;
        otherCollider = Character_Manager.playerCollider;
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
