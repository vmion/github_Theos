using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_bounds : MonoBehaviour
{
    [SerializeField]
    private BoxCollider Char_Collider; //������ �ڽ� �ö��̴�
    public BoxCollider portal; 
    public BoxCollider teleport_In;
    public BoxCollider teleport_Out;   
    Vector3 warp;
    public bool COLLISIONCHECK { get; set; }
    void Awake()
    {
        Char_Collider = GetComponent<BoxCollider>();        
        COLLISIONCHECK = true;
    }
    void Start()
    {
        warp = new Vector3(5, 0, 0);
    }
    void Update()
    {
        if (COLLISIONCHECK)
        {
            if (Char_Collider.bounds.Intersects(portal.bounds))
            {
                Debug.Log(portal.name + "�� bounds�浹");
            }
            if (Char_Collider.bounds.Intersects(teleport_In.bounds))
            {
                Char_Collider.gameObject.transform.position += warp;
                Debug.Log(teleport_In.name + "�� bounds�浹");
            }
            if (Char_Collider.bounds.Intersects(teleport_Out.bounds))
            {
                Char_Collider.gameObject.transform.position -= warp;
                Debug.Log(teleport_Out.name + "�� bounds�浹");
            }
        }        
    }
}
