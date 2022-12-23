using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_ani :  MonoBehaviour
{    
    [SerializeField]
    private Transform Char;
    [SerializeField]
    private Transform Cam;
    Animator ani;
    public Image hp;
    float moveSpeed;    
    Vector2 centerPos;
    Vector2 LcenterPos;
    public Image JoyStick;
    public Image JoyStick_Lever;
    void Start()
    {
        ani = Char.GetComponent<Animator>();
        Char.gameObject.SetActive(true);
        Char.transform.position = new Vector3(-15f, 0, 0);
        moveSpeed = 3f;
        centerPos = JoyStick.rectTransform.position;        
    }
    public void Move()
    {
        LcenterPos = JoyStick_Lever.rectTransform.position;
        Vector2 moveVec = (LcenterPos - centerPos).normalized;
        Vector2 moveInput = new Vector2(moveVec.x, moveVec.y);
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        ani.SetBool("isMove", isMove);        
        if(isMove)
        {
            Vector3 lookforward = new Vector3(Char.forward.x, 0f, Char.forward.z).normalized;
            Vector3 lookRight = new Vector3(Cam.right.x, 0f, Cam.right.z).normalized;
            Vector3 moveDir = lookforward * moveInput.y + lookRight * moveInput.x;
            Char.forward = lookforward;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
                               
            if (hp.fillAmount == 0)
            {
                ani.SetInteger("ani", 100);
            }
        }
        if (isMove == false)
        {            
            if (hp.fillAmount == 0)
            {
                ani.SetInteger("ani", 100);
            }
        }       
    }    
    public void LookAround()
    {
        
    }    
    void Update()
    {
        LookAround();
        Move();        
    }
}
