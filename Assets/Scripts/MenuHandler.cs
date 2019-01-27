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

    public int currentStory;
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
        menuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
        HighscoreCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        StoryCanvas.SetActive(false);
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
        StoryCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        HighscoreCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        nextStory();
    }
    public void nextStory()
    {
        Debug.Log("next story");
        storytime = true;
        Debug.Log(currentStory);
        switch (currentStory)
        {
            case 0:
                try
                {
                    menuCanvas.SetActive(false);
                    creditsCanvas.SetActive(false);
                    HighscoreCanvas.SetActive(false);
                    WinCanvas.SetActive(false);
                    GameOverCanvas.SetActive(false);
                    StoryCanvas.SetActive(true);

                }
                catch(System.Exception e)
                {
                    Debug.Log("error" + e);
                }
                Story0.SetActive(true);
                currentStory += 1;
                break;
            case 1:
                Story0.SetActive(false);
                Story1.SetActive(true);
                currentStory += 1;
                break;
            case 2:
                Story1.SetActive(false);
                Story2.SetActive(true);
                currentStory += 1;
                break;
            case 3:
                Story2.SetActive(false);
                Story3.SetActive(true);
                currentStory += 1;
                break;
            case 4:
                Story3.SetActive(false);
                Story4.SetActive(true);
                currentStory += 1;
                break;
            case 5:
                Story4.SetActive(false);
                Story5.SetActive(true);
                currentStory += 1;
                break;
            case 6:
                Story5.SetActive(false);
                Story6.SetActive(true);
                currentStory += 1 ;
                break;
            case 7:
                Story6.SetActive(false);
                menuCanvas.SetActive(true);
                currentStory = 0;
                break;
        }
        Debug.Log("ADD");
    }
}
