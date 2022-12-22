using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_joyStick : MonoBehaviour
{
    public Image JoyStick;
    public Image JoyStick_Lever;
    public GameObject Char;
    Vector2 dir;
    Vector2 centerPos;
    float radius;
    float moveSpeed;
    float rotSpeed;
    float rotAngle;
    void Start()
    {
        centerPos = JoyStick.transform.position;
        radius = JoyStick.rectTransform.rect.width * 0.5f;
        moveSpeed = 0f;
        rotSpeed = 3f;
        rotAngle = 0f;
        Char.transform.position.Set(-15f, 0f, 5f);
    }
    public void OnPointerDown(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log(eventData.position);
        JoyStick_Lever.transform.position = eventData.position;
    }
    public void OnPointerUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log("¶¿¶§ À§Ä¡ = " + eventData.position);
        JoyStick_Lever.transform.position = centerPos;
        moveSpeed = 0f;
    }
    public void OnBeginDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        JoyStick_Lever.transform.position = eventData.position;
        rotAngle = Vector3.Angle(centerPos, eventData.position);
        Char.transform.rotation = Quaternion.EulerRotation(0, rotAngle, 0);
    }
    public void OnDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        Debug.Log(eventData.position);
        float distance = Vector2.Distance(centerPos, eventData.position);
        if (distance > radius)
        {
            dir = (Vector2)eventData.position - centerPos;
            JoyStick_Lever.transform.position = centerPos + dir.normalized * radius * 0.5f;
        }
        else
        {
            JoyStick_Lever.transform.position = eventData.position;
        }
        rotAngle = Vector3.Angle(centerPos, eventData.position);
        Char.transform.rotation = Quaternion.EulerRotation(0, rotAngle, 0);
        /*
        rotAngle = Vector3.Angle(centerPos, eventData.position);
        Char.transform.Rotate(0, rotAngle, 0);
        */
    }

    public void OnEndDrag(BaseEventData _eventData)
    {
        JoyStick_Lever.transform.position = centerPos;
        moveSpeed = 0f;
    }
    void Update()
    {        
    }
}
