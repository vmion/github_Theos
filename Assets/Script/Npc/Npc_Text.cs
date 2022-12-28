using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
            string path = Application.dataPath + "/Resources/Dialog/" + "Script_" + npc.name +".csv";
            using (StreamReader sr = new StreamReader(path))
            {
                string lineData = string.Empty;
                while ((lineData = sr.ReadLine()) != null)
                {
                    string[] datas = lineData.Split(',');
                    for(int i = 0; i < datas.Length; i++)
                    {
                        dialog.text = datas[i];                        
                    }
                }
                sr.Close();
            }
        }
       
    }    

}
