using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static Collider monsterCollider { get; set; }    
    private static MonsterManager Instance;
    public static Dictionary<string, GameObject> mobDic;
    public static MonsterManager instance
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
    void Awake()
    {
        mobDic = new Dictionary<string, GameObject>();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Monsters/");
        mobDic.Add("켄타우로스", tmpObjs[0]);
        mobDic.Add("고르곤", tmpObjs[1]);
        mobDic.Add("사티르", tmpObjs[2]);
        mobDic.Add("아라크네", tmpObjs[3]);
        mobDic.Add("미노타우루스", tmpObjs[4]);
    }    
    void Update()
    {        
    }
}
