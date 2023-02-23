using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("탈리아를 구해라", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("열쇠 찾기", new int[] { 300, 2000 }));
        questList.Add(30, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }
    // Npc Id를 받아 퀘스트 번호를 반환하는 함수 
    public int GetQuestTalkIndex(int id) 
    {
        return questId + questActionIndex;
    }


    public string CheckQuest() //오버로딩 
    {
        //return Quest Name
        return questList[questId].questName;
    }


    public string CheckQuest(int id) //npc id
    {

        //Next Talk Target
        //매개변수로 받은 id가 
        if (id == questList[questId].NpdId[questActionIndex]) 
            questActionIndex++;


        //Control Quest Object
        ControlObject();

        //Talk complete & Next Quest
        //퀘스트 리스트에 있는 NpcId(퀘스트에 참여하는)
        if (questActionIndex == questList[questId].NpdId.Length) 
            NextQuest();

        //return Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;

    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                //10번 퀘스트를 끝마치면 열쇠 등장 
                if (questActionIndex == 2) 
                    questObject[0].SetActive(true);
                break;

            case 20:
                //20번 퀘스트에서 1번째 순서가 끝나고 -> 열쇠를 먹으면 열쇠 사라짐 
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
