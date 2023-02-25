using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager Instance;
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }    
    void GenerateData()
    {
        questList.Add(10, new QuestData("�Ҿ���� ���� ã�ƶ�", new int[] { 1000, 300 }));
        questList.Add(20, new QuestData("�� �����ֱ�", new int[] { 300, 1000 }));
        questList.Add(30, new QuestData("�̱� ����", new int[] { 2000, 3000 }));
        questList.Add(40, new QuestData("����Ʈ �� Ŭ����!", new int[] { 0 }));        
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
        {
            questActionIndex++;
        }         

        //Control Quest Object
        ControlObject();

        //Talk complete & Next Quest
        //����Ʈ ����Ʈ�� �ִ� NpcId(����Ʈ�� �����ϴ�)
        if (questActionIndex == questList[questId].NpdId.Length)
        {
            NextQuest();
        }            

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
