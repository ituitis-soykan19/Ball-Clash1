using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject mainScreen;
    public GameObject currentobject;
    public GameObject soundsScreen;
    public GameObject graphicsScreen;
    public GameObject controlsScreen;
    public void Start()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        graphicsScreen.SetActive(false);
        soundsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MaintoSettings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void SettingstoMain()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void SettingstoSound()
    {
        currentobject = soundsScreen;
        soundsScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void SettingstoGraphics()
    {
        currentobject = graphicsScreen;
        graphicsScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void SettingstoControls()
    {
        currentobject = controlsScreen;
        controlsScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void BacktoSettings()
    {
        currentobject.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
