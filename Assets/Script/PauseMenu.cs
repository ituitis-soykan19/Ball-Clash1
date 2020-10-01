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
    public void Start()
    {
        pauseMenu.SetActive(false);
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
