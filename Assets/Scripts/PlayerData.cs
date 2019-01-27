using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class PlayerData
{
    float[] hiScores;

    public int maxLevels
    {
        get;
        set;
    }

    protected PlayerData()
    {
    }

    public PlayerData(int maxLevels)
    {
        this.maxLevels = maxLevels;
        hiScores = new float[maxLevels];
    }

    public void SetScore(int levelNumber, float score)
    {
        hiScores[levelNumber] = score;
    }

    public float GetScore(int levelNumber)
    {
        return hiScores[levelNumber-1];
    }

    public void Save(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);

        bf.Serialize(file, this);
        file.Close();
    }

    public static PlayerData Load(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close();
        return data;
    }
}
