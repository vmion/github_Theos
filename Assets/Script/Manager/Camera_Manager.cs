using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    private static Camera_Manager Instance;
    public static Camera_Manager instance
    {
        get
        {
            if (null == Instance)
            {
                return null;
            }
            return Instance;
        }
    }
    public GameObject player;
    [SerializeField]
    private float xmove = 0;
    [SerializeField]
    private float ymove = 0;
    public float distance = 3;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        } 
    }
    
    void Update()
    {        
        xmove += Input.GetAxis("Mouse X"); 
        ymove -= Input.GetAxis("Mouse Y"); 
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); 
        Vector3 reverseDistance = new Vector3(0.0f, -2f, distance); 
        transform.position = player.transform.position - transform.rotation * reverseDistance;
    }
}
