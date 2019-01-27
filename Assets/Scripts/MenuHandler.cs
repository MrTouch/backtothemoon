using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject creditsCanvas;
    public GameObject HighscoreCanvas;
    public GameObject GameOverCanvas;
    public GameObject WinCanvas;
    public GameObject StoryCanvas;

    private int currentStory;
    public GameObject Story0;
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Story4;
    public GameObject Story5;
    public GameObject Story6;


    public bool storytime = false;

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

    public int currentSceneId()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public int maxScenes()
    {
        return SceneManager.sceneCount;
    }

    public void ShowMenu()
    {
        creditsCanvas.SetActive(false);
        HighscoreCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        StoryCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void ShowHighscores()
    {
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        HighscoreCanvas.SetActive(true);
        StoryCanvas.SetActive(false);
    }

    public void ShowAbout()
    {
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
        HighscoreCanvas.SetActive(false);
        StoryCanvas.SetActive(false);
    }

    public void ShowStory()
    {
        storytime = true;
        StoryCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        HighscoreCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
    }
    public void initStory()
    {
        currentStory = 0;
    }
    public void nextStory()
    {
        switch (currentStory)
        {
            case 0:
                menuCanvas.SetActive(false);
                Story0.SetActive(true);
                break;
            case 1:
                Story0.SetActive(false);
                Story1.SetActive(true);
                break;
            case 2:
                Story1.SetActive(false);
                Story2.SetActive(true);
                break;
            case 3:
                Story2.SetActive(false);
                Story3.SetActive(true);
                break;
            case 4:
                Story3.SetActive(false);
                Story4.SetActive(true);
                break;
            case 5:
                Story4.SetActive(false);
                Story5.SetActive(true);
                break;
            case 6:
                Story5.SetActive(false);
                Story6.SetActive(true);
                break;
            case 7:
                Story6.SetActive(false);
                menuCanvas.SetActive(true);
                currentStory = 0;
                break;
                
        }
        currentStory += 1;
    }
}
