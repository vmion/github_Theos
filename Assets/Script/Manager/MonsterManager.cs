using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public Collider monsterCollider { get; set; }
    Dictionary<string, GameObject> mobDic;
    private static MonsterManager Instance;
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
    }
    
    void Start()
    {
        mobDic.Clear();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Monsters/");
        for (int j = 0; j < tmpObjs.Length; j++)
        {
            mobDic.Add("��Ÿ��ν�", tmpObjs[0]);
            mobDic.Add("����", tmpObjs[1]);
            mobDic.Add("��Ƽ��", tmpObjs[2]);
        }
        Debug.Log("���� ���ҽ� �ε� �Ϸ�");
    }
    void Update()
    {        
    }
}
