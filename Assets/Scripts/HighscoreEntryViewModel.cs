using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreEntryViewModel : MonoBehaviour
{

    public Text PlayerText;
    public Text ScoreText;

 
    public void SetHighscoreData(HighscoreEntryData data)
    {
        PlayerText.text = data.PlayerName;
        ScoreText.text = data.Score.ToString();
    }
}
