using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ani : MonoBehaviour
{
    Animator ani;    
    Vector3 nextMove;
    bool isMoving;    
    Vector3 Center;
    public GameObject player;
    void Awake()
    {
        ani = GetComponent<Animator>();
        Center = transform.localPosition;
        isMoving = false;        
    }
    void Start()
    {        
        Invoke("AutoMove", 3f);        
    }
    void Update()
    {        
    }
    public void AutoMove()
    {
        isMoving = true;
        Transform movePos = GetComponent<Transform>();        
        nextMove.x = (int)Random.Range(-3f, 3f);
        nextMove.y = 0f;
        nextMove.z = (int)Random.Range(-3f, 3f);
        Vector3 dirMove = new Vector3(nextMove.x, 0f, nextMove.z);
        if (isMoving)
        {            
            ani.SetBool("isMoving", true);
            movePos.position += dirMove * Time.deltaTime * 1f;            
            movePos.forward = dirMove.normalized;
            Vector3 MPos = movePos.position;
            MPos.x = Mathf.Clamp(MPos.x, Center.x - 5f, Center.x + 5f);
            MPos.z = Mathf.Clamp(MPos.z, Center.z - 5f, Center.z + 5f);
        }
        float time = Random.Range(2f, 5f);
        isMoving = false;        
        Invoke("AutoMove", time);
    }    
}
