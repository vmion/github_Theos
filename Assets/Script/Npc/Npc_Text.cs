using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.IO;

public class Npc_Text : MonoBehaviour
{    
    public GameObject npc;    
    public GameObject panel;
    public Text dialog;
    void Start()
    {
        dialog.text = "";
        if(panel.activeSelf == true)
        {
            //TextAsset txt = Resources.Load<TextAsset>("Script_" + npc.name);
            TextAsset txt = Resources.Load<TextAsset>("Script_Chief");
            string[] arrData = txt.text.Split(',');
            foreach (string one in arrData)
            {
                dialog.text += one;         
            }
        }
       
    }    

}
