using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Manager : MonoBehaviour
{
    public Collider playerCollider { get; set; }      
    private static Character_Manager Instance;
    public static Character_Manager instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }    
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
}
