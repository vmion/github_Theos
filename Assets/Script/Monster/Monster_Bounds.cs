using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bounds : MonoBehaviour
{
    //public static Collider mobCollider { get; set; }
    Collider otherCollider;
    GameObject mob;
    void Awake()
    {
        //mobCollider = GetComponentInChildren<Collider>();
        //otherCollider = Character_Manager.playerCollider;        
    }
    void Start()
    {
        //mobCollider = GetComponentInChildren<Collider>();
        //mobCollider = MonsterManager.mobCollider;
        //Invoke("_GetCollider", 1f);
        //Debug.Log(MonsterManager.mobCollider.gameObject.name);        
    }
    IEnumerator GetCollider()
    {
        //mobCollider = GetComponentInChildren<Collider>();
        yield return null;
    }
    public void _GetCollider()
    {
        //mobCollider = MonsterManager.mobCollider;
    }
    void Update()
    {
        //Debug.Log(MonsterManager.mobCollider.gameObject.name);
        /*
        if(mobCollider.bounds.Intersects(otherCollider.bounds))
        {
            //mob.SetActive(false);
        }
        */
    }
}
