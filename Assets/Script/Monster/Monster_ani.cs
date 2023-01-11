using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ani : MonoBehaviour
{
    Animator ani;
    Dictionary<int, Vector3> centerDic;
    public static Vector3 distance;
    void Awake()
    {
        ani = GetComponent<Animator>();
        centerDic = new Dictionary<int, Vector3>();
        for(int i = 0; i < MonsterManager.CenterList.Count; i++)
        {
            Vector3 pos = MonsterManager.CenterList[i];
            centerDic.Add(i, pos);
        }
        distance = (centerDic[0] - centerDic[5]) / 2;
    }
    void Start()
    {
        //Debug.Log(name + "애니메이터");
        centerDic.Clear();
    }
    void Update()
    {
        
    }
    void Move()
    {
        
    }
    public static Vector3 ClampPosition(Vector3 _position)
    {
        Vector3 clampPos;
        clampPos.x = Mathf.Clamp(_position.x, _position.x - distance.x, _position.x + distance.x);
        clampPos.y = 0f;
        clampPos.z = Mathf.Clamp(_position.z, _position.z - distance.z, _position.z + distance.z);
        return clampPos;
    }
}
