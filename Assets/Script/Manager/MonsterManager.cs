using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static Collider[] monsterCollider { get; set; }     
    private static MonsterManager Instance;
    public static Dictionary<string, GameObject> mobDic;
    public Transform ParentMonster;
    Collider otherCollider;
    public static MonsterManager instance
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
    void Start()
    {
        if (Application.CanStreamedLevelBeLoaded(3))
        {
            ForestSpawnAll();
        }        
        monsterCollider = GetComponentsInChildren<Collider>();
        otherCollider = Character_Manager.playerCollider;
    }
    public Vector3 GetCellCenterPos(int _r, int _c)
    {
        float cellxSize = Spawn_Manager.cellxSize;
        float cellzSize = Spawn_Manager.cellzSize;
        float xStartpos = Spawn_Manager.xStartpos;
        float zStartpos = Spawn_Manager.zStartpos;
        Vector3 pos = Vector3.zero;
        pos.x = xStartpos + cellxSize * _c + cellxSize * 0.5f;
        pos.y = 1f;
        pos.z = zStartpos - cellzSize * _r - cellzSize * 0.5f;
        return pos;        
    }
    public void ForestSpawnAll()
    {
        int row = Spawn_Manager.row;
        int column = Spawn_Manager.column;
        int tileIndex = row * column;
        for (int i = 0; i < tileIndex; i++)
        {
            int nR = i / column;
            int nC = i % column;
            Vector3 centerPos = GetCellCenterPos(nR, nC);            
            if (i % 3 == 0)
            {
                GameObject mob = Instantiate(MonsterManager.mobDic["켄타우로스"], ParentMonster);
                mob.tag = "Monster";
                mob.transform.position = centerPos;
                mob.AddComponent<Monster_ani>();                
            }
            else if (i % 3 == 1)
            {
                GameObject mob = Instantiate(MonsterManager.mobDic["고르곤"], ParentMonster);
                mob.tag = "Monster";
                mob.transform.position = centerPos;
                mob.AddComponent<Monster_ani>();                
            }
            else
            {
                GameObject mob = Instantiate(MonsterManager.mobDic["사티르"], ParentMonster);
                mob.tag = "Monster";
                mob.transform.position = centerPos;
                mob.AddComponent<Monster_ani>();                
            }
        }
    }
    void Update()
    {
        /*
        for(int i = 0; i < monsterCollider.Length; i++)
        {
            if (monsterCollider[i].bounds.Intersects(otherCollider.bounds))
            {
                monsterCollider[i].gameObject.SetActive(false);
            }
        } 
        */
    }
}
