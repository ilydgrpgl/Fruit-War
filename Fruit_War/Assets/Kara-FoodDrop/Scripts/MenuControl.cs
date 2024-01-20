using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIkon = default;

    [SerializeField]
    Button musicButton = default;

    [SerializeField]
    public Text HighScoreText;

   
   
   
    void Start()
    {
        
        if (Options.MusicRecording() == false)
        {
            Options.musicOpenSet(1);
        }
        MusicSettings();
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        HighScoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");


    }
    public void HighestScore()
    {
        SceneManager.LoadScene("Score");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Music()
    {
        if (Options.musicOpenGet()==1)
        {
            Options.musicOpenSet(0);
            musicButton.image.sprite = musicIkon[0];
        }

        else
        {
            Options.musicOpenSet(1);
            musicButton.image.sprite = musicIkon[1];
        }
    }
    void MusicSettings()
    {
        if(Options.musicOpenGet() == 1)
        {
            musicButton.image.sprite = musicIkon[1];
        }
        else
        {
            musicButton.image.sprite = musicIkon[0];
        }
    }
}
