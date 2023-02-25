using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Type : MonoBehaviour
{
    string targetMsg;
    public int CharPerSeconds;
    Text msgText;
    int index;
    public GameObject questButton;
    float interval;
    private void Awake()
    {
        msgText = GetComponent<Text>();
    }
    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }
    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        questButton.SetActive(false);
        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", 1 / interval);
    }
    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", 1 / interval);
    }
    void EffectEnd()
    {
        questButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
