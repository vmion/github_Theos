using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ani : MonoBehaviour
{
    Animator ani;
    Dictionary<int, Vector3> centerDic;
    public static Vector3 distance;
    public Vector3 nextMove;
    bool isMoving;
    public GameObject player;
    
    void Awake()
    {
        ani = GetComponent<Animator>();
        centerDic = new Dictionary<int, Vector3>();              
        isMoving = false;
    }
    void Start()
    {
        //Debug.Log(name + "애니메이터");
        for (int i = 0; i < MonsterManager.CenterList.Count; i++)
        {
            Vector3 pos = MonsterManager.CenterList[i];
            centerDic.Add(i, pos);
        }
        distance = (centerDic[0] - centerDic[5]) / 2;
        centerDic.Clear();
        Invoke("Move", 5f);
    }
    void Update()
    {
        if(isMoving)
        {
            ani.SetBool("isMoving", isMoving);            
            transform.position += nextMove * Time.deltaTime * 1f;
        }
    }
    void Move()
    {
        isMoving = true;
        nextMove.x = Random.Range(-0.3f, 1f);
        nextMove.y = 0f;
        nextMove.z = Random.Range(-0.3f, 1f);
        float time = Random.Range(2f, 5f);        
        Invoke("Move", time);
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
