using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Weapon : MonoBehaviour
{
    public Rigidbody weapon;
    void Start()
    {
        weapon = GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(weapon.gameObject.name);
    }
}
