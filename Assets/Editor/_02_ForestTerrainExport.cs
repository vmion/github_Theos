using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class _02_ForestTerrainExport : EditorWindow
{
    [MenuItem("Export/_02_ForestTerrainExport")]
    public static void ExportData()
    {
        Debug.Log("ExportData");
        string path = Application.dataPath + "/" + "_02_ForestTerrainExport.csv";
        Dictionary<Object, int> TerrainList = new Dictionary<Object, int>();
        using (StreamWriter sr = new StreamWriter(path))
        {
            string lineData = "index,name,parent,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez";
            sr.WriteLine(lineData);
            GameObject[] buildings = GameObject.FindGameObjectsWithTag("Terrain");
            for (int i = 0; i < buildings.Length; i++)
            {
                lineData = string.Empty;
                lineData += (i + 1).ToString();
                lineData += ",";
                lineData += buildings[i].name;
                lineData += ",";
                if (buildings[i].transform.parent.name == "Forest")
                    lineData += "-1";
                else
                {
                    lineData += TerrainList[buildings[i].transform.parent.gameObject].ToString();
                }
                lineData += ",";
                lineData += buildings[i].transform.localPosition.x;
                lineData += ",";
                lineData += buildings[i].transform.localPosition.y;
                lineData += ",";
                lineData += buildings[i].transform.localPosition.z;
                lineData += ",";
                lineData += buildings[i].transform.eulerAngles.x;
                lineData += ",";
                lineData += buildings[i].transform.eulerAngles.y;
                lineData += ",";
                lineData += buildings[i].transform.eulerAngles.z;
                lineData += ",";
                lineData += buildings[i].transform.localScale.x;
                lineData += ",";
                lineData += buildings[i].transform.localScale.y;
                lineData += ",";
                lineData += buildings[i].transform.localScale.z;
                sr.WriteLine(lineData);
                TerrainList.Add(buildings[i], i + 1);
            }
            sr.Close();
            TerrainList.Clear();
        }
    }
}