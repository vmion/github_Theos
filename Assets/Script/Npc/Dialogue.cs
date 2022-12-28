using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string name; //대사치는 캐릭터
    public string[] contexts; // 대사내용 
}
[System.Serializable]
public class DialogueEvent
{
    public string name;
    public Vector2 line;
    public Dialogue[] dialogues;
}
