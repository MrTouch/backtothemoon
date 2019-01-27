using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public PlayerController Player;
    public float _elapsedTime = 0;

    public bool isRunning = false;

    public GameObject IntroScreen;
    public GameObject GameOverScreen;
    public Highscores Highscore;
    public Text TimeText;

    private GameState CurrentGameState = GameState.INTRO;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.INTRO;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            _elapsedTime += Time.deltaTime;
            TimeText.text = $"Time: {Math.Round(_elapsedTime, 3)}";
        }
    }

    public void StartCountdownPhase()
    {
        if (this.CurrentGameState != GameState.INTRO)
            return;
    }

    public void StartRacePhase()
    {
        if (this.CurrentGameState != GameState.COUNTDOWN)
            return;

        isRunning = true;

    }

    public void FinishRace()
    {
        isRunning = false;
        this.Highscore.AddHighscoreEntry("Test", _elapsedTime); //time in seconds
    }



}


public enum GameState
{
    INTRO,
    COUNTDOWN,
    RACING,
    RACE_OVER
}
