using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Options 
{
    private const string HighScoreKey = "HighScore";
    

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }
    public static void UpdateHighScore(int currentScore)
    {
        int savedHighScore = GetHighScore();

        if (currentScore > savedHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, currentScore);
            PlayerPrefs.Save();
        }
    }
    

    public static void musicOpenSet(int musicOpen)
    {
        PlayerPrefs.SetInt("musicOpen", musicOpen);
    }

    public static int musicOpenGet()
    {
        return PlayerPrefs.GetInt("musicOpen", 0);
    }

    public static bool MusicRecording()
    {
        return PlayerPrefs.HasKey("musicOpen");
    }
}
