using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Manager : MonoBehaviour
{
    public static Collider playerCollider { get; set; }      
    private static Character_Manager Instance;
    public static Dictionary<string, GameObject> charDic;
    public Transform ParentPlayer;
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
        charDic = new Dictionary<string, GameObject>();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Character/");
        charDic.Add("�÷��̾�", tmpObjs[0]);
        LogIN();
    }
    void LogIN()
    {
        GameObject player = Instantiate(charDic["�÷��̾�"], ParentPlayer);
        player.tag = "Player";
        player.transform.position = ParentPlayer.transform.position;     
    }
    void Start()
    {
        playerCollider = Instance.GetComponentInChildren<Collider>();
        Debug.Log("manager = " + playerCollider.gameObject.name);
    }    
}
