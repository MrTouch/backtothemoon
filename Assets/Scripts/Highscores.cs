using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Highscores : MonoBehaviour {

    private List<HighscoreEntryData> _highscores = new List<HighscoreEntryData>();

    public GameObject Entry;

    public float SpaceBetweenEntries = 10;

    public void Start()
    {
        // test data
        this.AddHighscoreEntry("test1", 13);
        this.AddHighscoreEntry("test2", 2);
        this.AddHighscoreEntry("test3", 3);
        this.AddHighscoreEntry("test4", 1);
        this.AddHighscoreEntry("test5", 2);
        this.AddHighscoreEntry("test6", 10);
        this.AddHighscoreEntry("test7", 28);
        this.AddHighscoreEntry("test8", 239.15481f);
        this.AddHighscoreEntry("test9", 1.12341f);
        this.AddHighscoreEntry("test10", 14.313f);
        this.AddHighscoreEntry("test11", 5);
        this.AddHighscoreEntry("test12", 3);
        BuildScoreBoard();
    }

    public void AddHighscoreEntry(string playerName, float score)
    {
        this._highscores.Add(new HighscoreEntryData(playerName, score));
    }

    public void BuildScoreBoard()
    {
        var oldEntries = this.GetComponentsInChildren<HighscoreEntryViewModel>();
        
        foreach(var oldEntry in oldEntries)
        {
            GameObject.Destroy(oldEntry.gameObject);
        }

        var shownEntries = _highscores.OrderBy(i => i.Score).Take(10).ToList();

        for(int i =0; i< shownEntries.Count; i++)
        {
            Debug.Log("creating item");
            var newEntry = GameObject.Instantiate(Entry);
            newEntry.transform.parent = this.transform;
            var anchorTransform = newEntry.GetComponent<RectTransform>();
            anchorTransform.parent = this.GetComponent<RectTransform>();

            anchorTransform.anchoredPosition = new Vector2(0,  -i * (anchorTransform.rect.height + SpaceBetweenEntries));
            Debug.Log($"setting item to position {anchorTransform.anchoredPosition.x} / {anchorTransform.anchoredPosition.y} - rect height {anchorTransform.rect.height}");
            newEntry.GetComponent<HighscoreEntryViewModel>().SetHighscoreData(shownEntries[i]);
        }

    }

}

public class HighscoreEntryData
{
    public string PlayerName { get; }

    public float Score { get; }

    public HighscoreEntryData(string name, float score)
    {
        this.PlayerName = name;
        this.Score = score;
    }
}
