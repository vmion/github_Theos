using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    //0:���ڴ� ������ ���� 1:�鼳���� 2:��

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //��� ���� (obj id, ��ȭ )
        talkData.Add(1000, new string[] { "�ȳ��ϼ���:0", "�� �� �����ֽǷ���?:0", });
        talkData.Add(2000, new string[] { "�ȳ�:1", "�� �������� ó���̴�?:1", });
        talkData.Add(100, new string[] { "��� ������� �����̴�.", "������̴� �� �� ���� �� ����.", });
        talkData.Add(200, new string[] { "����� ���̴�. \n�� �� ���� �� ����", });
        talkData.Add(300, new string[] { "����� �����. \n��� �� �� ������?", });


        //����Ʈ�� ��ȭ(obj id + quest id + questIndex(������ȣ))
        //����Ʈ�� ��ȭ(obj id + quest id)

        //10�� ����Ʈ 
        talkData.Add(1000 + 10, new string[] { "��? �̷����� �����?!?!:2", "�����! \n�� �� �����ּ���:0", "�� ���� ���� �輼��?:2", "���� �� �𸣰ھ��. \n���� �ƹ����� �� �̻��ؼ���:0", "���� ��� �ص帮�� �ɱ��?:2", "���͵��� ���踦 ������ �־��. \n�װ��� ���ش� �ֽø� ���� ���� ����� �˷��帱�Կ�!:0", "��! ��ø� ��ٸ�����:2", });
        talkData.Add(1000 + 10 + 1, new string[] { "���踦 ã���ּ���. \n��Ź�����:0", });
        talkData.Add(2000 + 10 + 1, new string[] { "�ȳ�:1", "�ȳ��ϼ���? \nȤ�� ���踦 ���� �� �ִ� ���� �ƽó���?:2", "����? ������ �� ���� ������ �ִ°� �� �� ����:1", "�����մϴ�:2", });

        //20�� ����Ʈ
        talkData.Add(1000 + 20, new string[] { "���踦 ã���ּ���. \n��Ź�����:0", });
        talkData.Add(2000 + 20, new string[] { "���� ��ã�Ҵ�? \n���� ���������� �������� �� ���� �־���:1", }); //����Ʈ �Ϸ� ���� ��ȭ�� �ɾ��� ��
        talkData.Add(300 + 20, new string[] { "���踦 ã�Ҵ�", });
        talkData.Add(1000 + 20 + 1, new string[] { "���踦 ã���༭ ������!:0", "�� ��������!:2", }); //���踦 ã�� �Ŀ� 


        //30�� ����Ʈ 
        talkData.Add(1000 + 30, new string[] { "���踦 ã���༭ ������!:0", "�� ��������!:2", });

        //�ʻ�ȭ ���� (obj id + portrait number)
        portraitData.Add(1000 + 0, portraitArr[0]); //0�� �ε����� ����� �ʻ�ȭ�� id = 1000�� mapping
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]); //2�� �ε����� ����� �ʻ�ȭ�� id = 1002�� mapping

        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 2, portraitArr[2]);
    }

    /*
        public string GetTalk(int id, int talkIndex) //Object�� id , string�迭�� index
        {
    */
    //����ó��
    /*
    1. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        -> 1) �ش� ����Ʈ�� index(0) ó���� ��簡 ���� ��  
                -> ��� 
        -> 2) �ش� ����Ʈ�� index(0) ó���� ��簡 ���� ��
                -> ����Ʈ 0�� (�׳� �⺻���) ���


    2. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        -> ���


    */

    /*
            //1. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
            //�ش� ����Ʈ ���� ���� ��簡 ���� �� 
            if(!talkData.ContainsKey(id)){

                if(!talkData.ContainsKey(id - id%10)) //����Ʈ �� ó�� ��縶�� ���� ��,
                //�ش� ����Ʈ ��ü�� ��簡 ���� �� -> �⺻ ��縦 �ҷ��� (��, ���� �ڸ� �κ� ���� )
                {
                    if(talkIndex == talkData[id - id%100].Length)
                        return null;

                    else
                        return talkData[id - id%100][talkIndex];

                }
                else//����Ʈ �� ó�� ��簡 ���� �� �� 
                {
                //����Ʈ �� ó�� ��縦 ������ ��
                    if(talkIndex == talkData[id - id%10].Length)
                        return null;

                    else
                        return talkData[id - id%10][talkIndex];
                }
            }

            //2. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
            if(talkIndex==talkData[id].Length)
                return null;
            else
                return talkData[id][talkIndex]; //�ش� ���̵��� �ش�
        }

    */
    public string GetTalk(int id, int talkIndex)
    {
        //1. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        if (!talkData.ContainsKey(id))
        {

            //�ش� ����Ʈ ��ü�� ��簡 ���� �� -> �⺻ ��縦 �ҷ��� (��, ���� �ڸ� �κ� ���� )
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//GET FIRST TALK

            //
            else
                return GetTalk(id - id % 10, talkIndex);//GET FIRST QUEST TALK
        }

        //2. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //�ش� ���̵��� �ش�
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //id�� NPC�ѹ� , portraitIndex : ǥ����ȣ(?)
        return portraitData[id + portraitIndex];
    }
}
