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
        Time.timeScale = 1f;
        Obj_Portal.CamX = false;
    }
    public void OpenButton()
    {
        ui.SetActive(true);
        Time.timeScale = 0f;
        Obj_Portal.CamX = true;
    }
    public void CheckPortal_Village()
    {
        ui.SetActive(false);
        Obj_Portal.CamX = false;
        Time.timeScale = 1f;
        LoadingManager.LoadScene("_01_Village");        
    }
    public void CheckPortal_Forest()
    {
        ui.SetActive(false);
        Obj_Portal.CamX = false;
        Time.timeScale = 1f;
        LoadingManager.LoadScene("_02_Forest");          
    }
    public void CheckPortal_Labyrinth()
    {
        ui.SetActive(false);
        Obj_Portal.CamX = false;
        Time.timeScale = 1f;
        LoadingManager.LoadScene("_03_Labyrinth");
    }
    public void AutoCombat()
    {
        ui.SetActive(false);
        Time.timeScale = 1f;
        Obj_Portal.CamX = false;
        gameObject.GetComponentInChildren<Char_Auto>().AutoMove();
    }
}
