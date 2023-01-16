using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public bool isGameOver;
    public Image hp;
    public GameObject over;    
    public void Awake()
    {
        isGameOver = false;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }        
    }
    IEnumerator FadeOutStart()
    {
        over.SetActive(true);
        for (float f = 1f; f > 0; f -= 0.2f)
        {
            Color c = over.GetComponent<Image>().color;
            c.a = f;
            over.GetComponent<Image>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        over.SetActive(false);
    }
    IEnumerator FadeInStart()
    {
        over.SetActive(true);
        for (float f = 0f; f < 1; f += 0.45f)
        {
            Color c = over.GetComponent<Image>().color;
            c.a = f;
            over.GetComponent<Image>().color = c;
            yield return null;
        }
    }   
    void Update()
    {        
        if(hp.fillAmount == 0)
        {            
            StartCoroutine(FadeInStart());
            Debug.Log("Die");
            isGameOver = true;            
        }
    }
}
