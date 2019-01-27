using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject aboutCanvas;
    public GameObject HighscoreCanvas;
    public GameObject GameOverCanvas;
    public GameObject WinCanvas;

    public void Quit()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadScene()
    {
        Debug.Log("next Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void reloadScene()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowMenu()
    {
        menuCanvas.SetActive(true);
        aboutCanvas.SetActive(false);
        HighscoreCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
    }

    public void ShowHighscores()
    {
        menuCanvas.SetActive(false);
        aboutCanvas.SetActive(false);
        HighscoreCanvas.SetActive(true);
    }

    public void ShowAbout()
    {
        menuCanvas.SetActive(false);
        aboutCanvas.SetActive(true);
        HighscoreCanvas.SetActive(false);
    }
}
