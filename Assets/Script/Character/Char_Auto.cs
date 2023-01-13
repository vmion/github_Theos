using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Auto : MonoBehaviour
{
    [SerializeField]
    private static Transform Char;
    Animator ani;
    Vector3 nextMove;
    bool isMove;
    Vector3 Center;
    GameObject[] mobs;
    void Awake()
    {
        Char = Character_Manager.instance.transform.GetChild(0);
        ani = Char.GetComponent<Animator>();
    }
    public void AutoMove()
    {
        if(GameObject.FindGameObjectsWithTag("Monster") != null)
        {
            isMove = true;
            Transform movePos = GetComponent<Transform>();
            nextMove.x = (int)Random.Range(-3f, 3f);
            nextMove.y = 0f;
            nextMove.z = (int)Random.Range(-3f, 3f);
            Vector3 dirMove = new Vector3(nextMove.x, 0f, nextMove.z);
            if (isMove)
            {
                ani.SetBool("isMove", true);
                movePos.position += dirMove * Time.deltaTime * 1f;
                movePos.forward = dirMove.normalized;
                Vector3 MPos = movePos.position;
                MPos.x = Mathf.Clamp(MPos.x, Center.x - 5f, Center.x + 5f);
                MPos.z = Mathf.Clamp(MPos.z, Center.z - 5f, Center.z + 5f);
            }
            float time = Random.Range(2f, 5f);
            isMove = false;
            Invoke("AutoMove", time);
        }
        else 
        {
            Debug.Log("주변에 몬스터가 없습니다.");
        }
    }    
}
