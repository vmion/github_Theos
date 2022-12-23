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
    Vector2 CcenterPos;
    Vector2 LCcenterPos;
    public Image Rotate_Camera;
    public Image Camera_Lever;
    void Start()
    {
        ani = Char.GetComponent<Animator>();        
        Char.parent.gameObject.transform.position = new Vector3(-15f, 0, 0);
        moveSpeed = 3f;
        centerPos = JoyStick.rectTransform.position;
        CcenterPos = Rotate_Camera.rectTransform.position;
    }
    public void Move()
    {
        LcenterPos = JoyStick_Lever.rectTransform.position;
        Vector2 moveVec = (LcenterPos - centerPos).normalized;
        //Vector2 moveInput = new Vector2(moveVec.x, moveVec.y);
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        ani.SetBool("isMove", isMove);        
        if(isMove)
        {
            Vector3 lookforward = new Vector3(Cam.forward.x, 0f, Cam.forward.z).normalized;
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
        LCcenterPos = Camera_Lever.rectTransform.position;
        Vector2 moveVec = (LCcenterPos - CcenterPos).normalized;
        //Vector2 rotateInput = new Vector2(moveVec.x, moveVec.y);
        Vector2 rotateInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = Cam.rotation.eulerAngles;
        float x = camAngle.x - rotateInput.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        Cam.rotation = Quaternion.Euler(x, camAngle.y + rotateInput.x, camAngle.z);
    }    
    void Update()
    {
        LookAround();
        Move();        
    }
}
