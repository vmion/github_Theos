using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState : MonoBehaviour
{
    public Obj_Data questState;
    public GameObject objQuest;
    public GameObject objComplete;
    public QuestManager questLevel;
    //����Ʈ �³� ����
    bool isOkay;
    //����Ʈ �Ϸ� ����
    bool isCheck;
    void Update()
    {
        if(questState.isQuest == true)
        {
            objQuest.SetActive(true);
        }
        else if(questState.isQuest == false)
        {
            objQuest.SetActive(false);
        }
        if(questState.isComplete == true)
        {
            objComplete.SetActive(true);
        }
        else if(questState.isComplete == false)
        {
            objComplete.SetActive(false);
        }
        /*
        switch(questLevel.questId)
        {
            case 10:
                if(isOkay == false)
                {
                    questState.isQuest = true;
                    objQuest.SetActive(true);
                }
                else if(isOkay == true)
                {
                    questState.isQuest = false;
                    objQuest.SetActive(false);
                }
                //����Ʈ �Ϸ�� 
                if (questLevel.questActionIndex == 2)
                {
                    isCheck = false;
                    questState.isComplete = true;
                    objComplete.SetActive(true);
                }
                if(isCheck == true)
                {
                    questState.isComplete = false;
                    objComplete.SetActive(false);
                }
                    
                break;
           
        }
        */
            
    }
}
