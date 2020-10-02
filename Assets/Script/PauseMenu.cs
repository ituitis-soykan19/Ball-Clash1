using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject ongameobjects;
    public Text pausetable;

    public Vector3 PauseTableInitialPosition;

    public void Start()
    {
        pauseMenu.SetActive(false);
        PauseTableInitialPosition = pausetable.GetComponent<RectTransform>().anchoredPosition; 
    }
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        ongameobjects.SetActive(false);
        var rectpausetable = pausetable.GetComponent<RectTransform>();
        rectpausetable.anchoredPosition = new Vector3(922.93f, -348f, 0f);
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        ongameobjects.SetActive(true);
        pausetable.GetComponent<RectTransform>().anchoredPosition = PauseTableInitialPosition;
    }
    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
