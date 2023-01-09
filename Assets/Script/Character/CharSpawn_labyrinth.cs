using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpawn_labyrinth : MonoBehaviour
{
    public GameObject Boss;
    public 
    Transform player;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask clickMask;
    void Start()
    {        
        
    }
    void Update()
    {
        camera = Camera_Manager.instance.GetComponent<Camera>();
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, clickMask))
        {
            Debug.Log(hit.point);
            Vector3 objectHit = hit.point;
            if (objectHit == Boss.transform.position)
            {
                Transform bossHp = UI_Manager.instance.transform.Find("BossState");
                Debug.Log(bossHp.gameObject.name + "bossHp");
                bossHp.gameObject.SetActive(true);
            }
        }
    }
}
