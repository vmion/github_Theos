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
        questList.Add(10, new QuestData("Ż���Ƹ� ���ض�", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("���� ã��", new int[] { 300, 2000 }));
        questList.Add(30, new QuestData("����Ʈ �� Ŭ����!", new int[] { 0 }));
    }
    // Npc Id�� �޾� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ� 
    public int GetQuestTalkIndex(int id) 
    {
        return questId + questActionIndex;
    }


    public string CheckQuest() //�����ε� 
    {
        //return Quest Name
        return questList[questId].questName;
    }


    public string CheckQuest(int id) //npc id
    {

        //Next Talk Target
        //�Ű������� ���� id�� 
        if (id == questList[questId].NpdId[questActionIndex]) 
            questActionIndex++;


        //Control Quest Object
        ControlObject();

        //Talk complete & Next Quest
        //����Ʈ ����Ʈ�� �ִ� NpcId(����Ʈ�� �����ϴ�)
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
                //10�� ����Ʈ�� ����ġ�� ���� ���� 
                if (questActionIndex == 2) 
                    questObject[0].SetActive(true);
                break;

            case 20:
                //20�� ����Ʈ���� 1��° ������ ������ -> ���踦 ������ ���� ����� 
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
