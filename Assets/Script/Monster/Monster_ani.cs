using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ani : MonoBehaviour
{
    Animator ani;
    void Awake()
    {
        ani = GetComponent<Animator>();
    }
    void Start()
    {
        //Debug.Log(name + "애니메이터");
    }
    void Update()
    {
        
    }
}
