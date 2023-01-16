using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character_Manager : MonoBehaviour
{
    public static Collider playerCollider { get; set; }      
    private static Character_Manager Instance;
    public static Dictionary<string, GameObject> charDic;
    public static Transform ParentPlayer;    
    //public static Collider collider;
    public static Character_Manager instance
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
        ParentPlayer = GameObject.Find("Player").transform;
        charDic = new Dictionary<string, GameObject>();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Character/");
        charDic.Add("플레이어", tmpObjs[0]);

        SceneManager.sceneLoaded += ChangeSceneEvent;
    }
    void LogIN()
    {
        if(!GameObject.Find("Character(Clone)"))
        {
            GameObject player = Instantiate(charDic["플레이어"], ParentPlayer);
            player.tag = "Player";
            player.transform.position = ParentPlayer.transform.position;
        }        
    }
    void ChangeSceneEvent(Scene _scene, LoadSceneMode _mode)
    {               
        if (_scene.name == "_01_Village")
        {
            Instance.transform.position = new Vector3(-15, 0, 0);
        }
        if (_scene.name == "_02_Forest")
        {
            Instance.transform.position = new Vector3(-40, 0, -15);
        }
        if (_scene.name == "_03_Labyrinth")
        {
            Instance.transform.position = new Vector3(-45, 0, 45);
        }        
    }
    void Start()
    {        
        LogIN();     
        playerCollider = Instance.GetComponentInChildren<Collider>();
        Debug.Log("manager = " + playerCollider.gameObject.name);        
    }    
}
