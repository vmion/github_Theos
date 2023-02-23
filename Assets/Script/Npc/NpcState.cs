using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState : MonoBehaviour
{
    public Obj_Data questState;
    public GameObject objQuest;
    public GameObject objComplete;
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
    }
}
