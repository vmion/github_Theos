using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string name; //���ġ�� ĳ����
    public string[] contexts; // ��系�� 
}
[System.Serializable]
public class DialogueEvent
{
    public string name;
    public Vector2 line;
    public Dialogue[] dialogues;
}
