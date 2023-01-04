using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CellInfo
{
    public int arrIndex;
    public Vector3 centerPos;
}
public class Spawn_Manager : MonoBehaviour
{    
    Vector3 size;
    public int row; 
    public int column; 
    float cellxSize;
    float cellzSize;
    float xStartpos;
    float zStartpos;
    Dictionary<int, CellInfo> cellDic;
    //Dictionary<string, GameObject> mobDic;
    private void Awake()
    {
        cellDic = new Dictionary<int, CellInfo>();
        //mobDic = new Dictionary<string, GameObject>();
    }
    void Start()
    {
        GetMapsize();
        cellxSize = size.x / (float)column;
        cellzSize = size.z / (float)row;
        xStartpos = transform.position.x - size.x * 0.5f;
        zStartpos = transform.position.z + size.z * 0.5f;
        Initialize();
        SpawnAll();
        //Invoke("SpawnAll", 10f);        
    }
    public void Initialize()
    {
        cellDic.Clear();
        int tileCount = row * column;
        for (int i = 0; i < tileCount; i++)
        {
            int r = i / column;
            int c = i % column;           
            Vector3 centerPos = GetCellCenterPos(r, c);            
            CellInfo cellInfo = new CellInfo();
            cellInfo.arrIndex = i;
            cellInfo.centerPos = centerPos;
            cellDic.Add(i, cellInfo);
        }
    }    
    public Vector3 GetCellCenterPos(int _r, int _c)
    {
        Vector3 pos = Vector3.zero;
        pos.x = xStartpos + cellxSize * _c + cellxSize * 0.5f;
        pos.y = 1f;
        pos.z = zStartpos - cellzSize * _r - cellzSize * 0.5f;
        return pos;
    }
    
    public void SpawnAll()
    {
        int tileIndex = row * column;
        CellInfo cellInfo = new CellInfo();
        Vector3 tmp = Vector3.zero;
        for (int i = 0; i < tileIndex; i++)
        {
            int nR = i / column;
            int nC = i % column;
            Vector3 centerPos = GetCellCenterPos(nR, nC);  
            /*
            GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Monsters/");            
            for (int j = 0; j < tmpObjs.Length; j++)
            {
                mobDic.Add("Centaur", tmpObjs[0]);
                mobDic.Add("Gorgon", tmpObjs[1]);
                mobDic.Add("Satyr", tmpObjs[2]);
            }
            GameObject SpawnMob = Instantiate(mobDic.Values)
            gorgon.tag = "Monster";
            gorgon.transform.position = centerPos;
            
            foreach(GameObject one in tmpObjs)
            {
                if(one. == CellInfo.arrIndex)
                one.SetActive(true);
                one.transform.position = cellInfo.centerPos;
            } 
            */
        }
    }
    public void GetMapsize()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Vector3[] vertexs = meshFilter.mesh.vertices;
        float xMin, xMax, zMin, zMax;
        xMin = vertexs[0].x;
        xMax = vertexs[0].x;
        zMin = vertexs[0].z;
        zMax = vertexs[0].z;
        for (int i = 1; i < vertexs.Length; i++)
        {
            if (xMin > vertexs[i].x)
                xMin = vertexs[i].x;
            if (zMin > vertexs[i].z)
                zMin = vertexs[i].z;
            if (xMax < vertexs[i].x)
                xMax = vertexs[i].x;
            if (zMax < vertexs[i].z)
                zMax = vertexs[i].z;
        }        
        Vector3 tmp1 = new Vector3(xMin, 0, zMin);
        Vector3 tmp2 = new Vector3(xMax, 0, zMax);
        Vector3 worldMin = transform.TransformPoint(tmp1);
        Vector3 worldMax = transform.TransformPoint(tmp2);
        size.x = (worldMax.x - worldMin.x);
        size.z = (worldMax.z - worldMin.z);
        Debug.Log(size.x + " X " + size.z + "사이즈의 맵이다.");
    }
    
    void Update()
    {
    }    
}
