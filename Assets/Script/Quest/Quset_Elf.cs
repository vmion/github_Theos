using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quset_Elf : MonoBehaviour
{
    Text questText;
    GameObject panel;
    TalkManager talk;
    Obj_Data state;
    int id = 1000;
    int talkindex = 40;

    void Start()
    {        
        panel = GameObject.Find("Canvas").transform.Find("Elf_Panel").gameObject;        
        questText = panel.GetComponentInChildren<Text>();
        Debug.Log(questText.text);
        questText.text = talk.GetTalk(id, talkindex);
    }
    void Update()
    {
        if(state.isQuest == true)
        {
            questText.text = talk.GetTalk(id + 10 , talkindex);
        }
        if(state.isComplete == true)
        {
            questText.text = talk.GetTalk(id + 10 + 1, talkindex);
        }
    }
}
