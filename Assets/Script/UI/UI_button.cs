using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_button : MonoBehaviour
{    
    public GameObject ui;
    public void CloseButton()
    {
        ui.SetActive(false);
    }
    public void OpenButton()
    {
        ui.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void CheckPortal_Forest()
    {
        LoadingManager.LoadScene("_02_Forest");
    }
    public void CheckPortal_Labyrinth()
    {
        LoadingManager.LoadScene("_03_Labyrinth");
    }
}
