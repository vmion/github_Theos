using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{ 
    public void LoadScene()
    {
        LoadingManager.LoadScene("_01_Village");
    }
}
