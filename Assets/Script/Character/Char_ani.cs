using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_ani :  MonoBehaviour
{
    private static Char_ani Instance;
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
    [SerializeField]
    private Image Skill_1;
    [SerializeField]
    private Image Skill_2;
    [SerializeField]
    private Image Skill_3;
    [SerializeField]
    private Image Skill_4;
    [SerializeField]
    private Image Portion;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {        
        ani = Char.GetComponent<Animator>();        
        Char.parent.gameObject.transform.position = new Vector3(-15f, 0, 0);
        Char.parent.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
        moveSpeed = 3f;
        centerPos = JoyStick.rectTransform.position;
        CcenterPos = Rotate_Camera.rectTransform.position;
        ani.SetInteger("ani", 0);
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
    public void ButtonSkill()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Skill_1.fillAmount == 1)
            {                
                StartCoroutine(CoolTime(Skill_1, 1));
                ani.SetInteger("ani", 1);             
            }
            else
            {
                Debug.Log("��Ÿ���Դϴ�.");                
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Skill_2.fillAmount == 1)
            {
                StartCoroutine(CoolTime(Skill_2, 3));
                ani.SetInteger("ani", 2);
            }
            else
            {
                Debug.Log("��Ÿ���Դϴ�.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Skill_3.fillAmount == 1)
            {
                StartCoroutine(CoolTime(Skill_3, 5));
                ani.SetInteger("ani", 3);
            }
            else
            {
                Debug.Log("��Ÿ���Դϴ�.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Skill_4.fillAmount == 1)
            {
                StartCoroutine(CoolTime(Skill_4, 8));
                ani.SetInteger("ani", 4);
            }
            else
            {
                Debug.Log("��Ÿ���Դϴ�.");
            }
        }
    }
    public void ButtonPortion()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (Portion.fillAmount == 1 && hp.fillAmount != 1)
            {
                hp.fillAmount += 0.2f;
                StartCoroutine(CoolTime(Portion, 10));
            }
            else
            {
                Debug.Log("��Ÿ���Դϴ�.");
            }
            if(hp.fillAmount == 1)
            {
                Debug.Log("HP�� ���� �� �ֽ��ϴ�.");
            }
        }
    }
    public void AfterDelay()
    {
        ani.SetInteger("ani", 0);
    }
    IEnumerator CoolTime(Image _image, float cool)
    {
        while(cool > 1.0f)
        {
            cool -= Time.deltaTime;
            _image.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
    }
    void Update()
    {
        LookAround();
        Move();
        ButtonSkill();
        ButtonPortion();
    }
}
