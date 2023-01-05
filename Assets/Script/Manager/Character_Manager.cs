using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Manager : MonoBehaviour
{
    public  static Collider playerCollider { get; set; }      
    private static Character_Manager Instance;
    public static Dictionary<string, GameObject> charDic;    
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
        charDic = new Dictionary<string, GameObject>();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Character/");
        charDic.Add("�÷��̾�", tmpObjs[0]);
    }
    void Start()
    {
        //GameObject player = Instantiate(charDic["�÷��̾�"], ParentPlayer);
        //GameObject tmpObj = Resources.Load<GameObject>("Character/");
        //GameObject player = Instantiate(tmpObj, ParentPlayer);
        //player.tag = "Player";
        //player.transform.position = new Vector3(-15f, 0, 0);
        //player.AddComponent<Char_ani>();
    }
}
