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
    public void CheckPortal_Village()
    {
        ui.SetActive(false);
        LoadingManager.LoadScene("_01_Village");
    }
    public void CheckPortal_Forest()
    {
        ui.SetActive(false);
        LoadingManager.LoadScene("_02_Forest");
    }
    public void CheckPortal_Labyrinth()
    {
        ui.SetActive(false);
        LoadingManager.LoadScene("_03_Labyrinth");
    }
}
