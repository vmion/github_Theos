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
    void Start()
    {
        if (Application.CanStreamedLevelBeLoaded(4))
        {
            player = Character_Manager.instance.GetComponentInChildren<Transform>();
            Vector3 spawn = new Vector3(45f, 1f, 45f);
            player.position = spawn;
        }
        camera = Camera_Manager.instance.GetComponent<Camera>();
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if(objectHit == Boss)
            {
                Transform bossHp = UI_Manager.instance.transform.Find("BossState");
                bossHp.gameObject.SetActive(true);
            }
        }
    }
    void Update()
    {
        
    }
}
