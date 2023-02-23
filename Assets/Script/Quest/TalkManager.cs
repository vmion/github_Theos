using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    //0:잠자는 숲속의 공주 1:백설공주 2:잭

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //대사 생성 (obj id, 대화 )
        talkData.Add(1000, new string[] { "안녕하세요:0", "문 좀 열어주실래요?:0", });
        talkData.Add(2000, new string[] { "안녕:1", "이 마을에는 처음이니?:1", });
        talkData.Add(100, new string[] { "쇠로 만들어진 감옥이다.", "열쇠없이는 열 수 없는 것 같다.", });
        talkData.Add(200, new string[] { "평범한 문이다. \n들어갈 수 있을 것 같다", });
        talkData.Add(300, new string[] { "평범한 열쇠다. \n어디에 쓸 수 있을까?", });


        //퀘스트용 대화(obj id + quest id + questIndex(순서번호))
        //퀘스트용 대화(obj id + quest id)

        //10번 퀘스트 
        talkData.Add(1000 + 10, new string[] { "엥? 이런곳에 사람이?!?!:2", "저기요! \n저 좀 도와주세요:0", "왜 여기 갇혀 계세요?:2", "저도 잘 모르겠어요. \n저희 아버지가 좀 이상해서요:0", "제가 어떻게 해드리면 될까요?:2", "몬스터들이 열쇠를 가지고 있어요. \n그것을 구해다 주시면 제가 좋은 기술을 알려드릴게요!:0", "네! 잠시만 기다리세요:2", });
        talkData.Add(1000 + 10 + 1, new string[] { "열쇠를 찾아주세요. \n부탁드려요:0", });
        talkData.Add(2000 + 10 + 1, new string[] { "안녕:1", "안녕하세요? \n혹시 열쇠를 구할 수 있는 곳을 아시나요?:2", "열쇠? 열쇠라면 문 옆에 떨어져 있는걸 본 것 같아:1", "감사합니다:2", });

        //20번 퀘스트
        talkData.Add(1000 + 20, new string[] { "열쇠를 찾아주세요. \n부탁드려요:0", });
        talkData.Add(2000 + 20, new string[] { "아직 못찾았니? \n내가 마지막으로 봤을때는 문 옆에 있었어:1", }); //퀘스트 완료 전에 대화를 걸었을 때
        talkData.Add(300 + 20, new string[] { "열쇠를 찾았다", });
        talkData.Add(1000 + 20 + 1, new string[] { "열쇠를 찾아줘서 고마워요!:0", "별 말씀을요!:2", }); //열쇠를 찾은 후에 


        //30번 퀘스트 
        talkData.Add(1000 + 30, new string[] { "열쇠를 찾아줘서 고마워요!:0", "별 말씀을요!:2", });

        //초상화 생성 (obj id + portrait number)
        portraitData.Add(1000 + 0, portraitArr[0]); //0번 인덱스에 저장된 초상화를 id = 1000과 mapping
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]); //2번 인덱스에 저장된 초상화를 id = 1002과 mapping

        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 2, portraitArr[2]);
    }

    /*
        public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
        {
    */
    //예외처리
    /*
    1. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 없음
        -> 1) 해당 퀘스트의 index(0) 처음에 대사가 있을 때  
                -> 출력 
        -> 2) 해당 퀘스트의 index(0) 처음에 대사가 없을 때
                -> 퀘스트 0번 (그냥 기본대사) 출력


    2. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 있음
        -> 출력


    */

    /*
            //1. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 없음
            //해당 퀘스트 진행 순서 대사가 없을 때 
            if(!talkData.ContainsKey(id)){

                if(!talkData.ContainsKey(id - id%10)) //퀘스트 맨 처음 대사마저 없을 때,
                //해당 퀘스트 자체에 대사가 없을 때 -> 기본 대사를 불러옴 (십, 일의 자리 부분 제거 )
                {
                    if(talkIndex == talkData[id - id%100].Length)
                        return null;

                    else
                        return talkData[id - id%100][talkIndex];

                }
                else//퀘스트 맨 처음 대사가 존재 할 때 
                {
                //퀘스트 맨 처음 대사를 가지고 옴
                    if(talkIndex == talkData[id - id%10].Length)
                        return null;

                    else
                        return talkData[id - id%10][talkIndex];
                }
            }

            //2. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 있음
            if(talkIndex==talkData[id].Length)
                return null;
            else
                return talkData[id][talkIndex]; //해당 아이디의 해당
        }

    */
    public string GetTalk(int id, int talkIndex)
    {
        //1. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 없음
        if (!talkData.ContainsKey(id))
        {

            //해당 퀘스트 자체에 대사가 없을 때 -> 기본 대사를 불러옴 (십, 일의 자리 부분 제거 )
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//GET FIRST TALK

            //
            else
                return GetTalk(id - id % 10, talkIndex);//GET FIRST QUEST TALK
        }

        //2. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 있음
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex]; //해당 아이디의 해당
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //id는 NPC넘버 , portraitIndex : 표정번호(?)
        return portraitData[id + portraitIndex];
    }
}
