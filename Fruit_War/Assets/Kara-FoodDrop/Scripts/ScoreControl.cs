




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{

    public Text scoreText;
    public int fruitScore = 0;
   
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Food")) // Meyve'nin "Food" etiketi varsa
        {

            fruitScore++;
            other.gameObject.SetActive(false);
            UpdateScoreText();
            PlayerPrefs.SetInt("CurrentScore", fruitScore);
            PlayerPrefs.Save();
            Options.UpdateHighScore(fruitScore);
        }
        
    }

   

    void UpdateScoreText()
    {
        // Text bileþenine puaný yazdýr
        scoreText.text = "Puan: " + fruitScore.ToString();
        
       
    }
    


}
