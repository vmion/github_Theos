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
        mobDic.Add("��Ÿ��ν�", tmpObjs[0]);
        mobDic.Add("����", tmpObjs[1]);
        mobDic.Add("��Ƽ��", tmpObjs[2]);
        mobDic.Add("�ƶ�ũ��", tmpObjs[3]);
        mobDic.Add("�̳�Ÿ��罺", tmpObjs[4]);
    }    
    void Update()
    {        
    }
}
