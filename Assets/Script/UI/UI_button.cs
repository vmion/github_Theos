using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
