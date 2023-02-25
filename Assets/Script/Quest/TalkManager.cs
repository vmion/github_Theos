using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    //Dictionary<int, Sprite> portraitData;
    //public Sprite[] portraitArr;
    //0:elf 1:chief

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        //portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //대사 생성 (obj id, 대화 )
        talkData.Add(1000, new string[] { "안녕하세요:0", });
        talkData.Add(2000, new string[] { "우리 마을을 찾아주셔서 감사합니다.:1", });       


        //퀘스트용 대화(obj id + quest id + questIndex(순서번호))
        //퀘스트용 대화(obj id + quest id)

        //10번 퀘스트 
        talkData.Add(1000 + 10, new string[] { "안녕하세요:0", "갑자기 죄송하지만 부탁을 들어주시겠어요?:0",
                        "초원에서 습격을 받아서 짐을 잃었습니다.:0", "몬스터를 사냥하고 짐을 찾아주시겠어요?:0",});
        talkData.Add(1000 + 10 + 1, new string[] { "감사합니다! 덕분에 다시 장사를 시작할 수 있겠네요!:0", });        

        //20번 퀘스트
        talkData.Add(1000 + 20, new string[] { "열쇠를 찾아주세요. \n부탁드려요:0", });
        talkData.Add(2000 + 20, new string[] { "아직 못찾았니? \n내가 마지막으로 봤을때는 문 옆에 있었어:1", }); //퀘스트 완료 전에 대화를 걸었을 때
        talkData.Add(300 + 20, new string[] { "열쇠를 찾았다", });
        talkData.Add(1000 + 20 + 1, new string[] { "열쇠를 찾아줘서 고마워요!:0", "별 말씀을요!:2", }); //열쇠를 찾은 후에 


        //30번 퀘스트 
        talkData.Add(1000 + 30, new string[] { "열쇠를 찾아줘서 고마워요!:0", "별 말씀을요!:2", });

        //초상화 생성 (obj id + portrait number)
        /*
        portraitdata.add(1000 + 0, portraitarr[0]); //0번 인덱스에 저장된 초상화를 id = 1000과 mapping
        portraitdata.add(1000 + 1, portraitarr[1]);
        portraitdata.add(1000 + 2, portraitarr[2]); //2번 인덱스에 저장된 초상화를 id = 1002과 mapping

        portraitdata.add(2000 + 0, portraitarr[0]);
        portraitdata.add(2000 + 1, portraitarr[1]);
        portraitdata.add(2000 + 2, portraitarr[2]);
        */
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
    /*
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //id는 NPC넘버 , portraitIndex : 표정번호
        return portraitData[id + portraitIndex];
    }
    */
}
