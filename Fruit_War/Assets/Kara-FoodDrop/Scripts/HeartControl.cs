using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeartControl : MonoBehaviour
{
   
    [SerializeField]
    Image[] hearts=default;

    [SerializeField]
    Image[] hearts2 = default;
    private int remainingLives = 3;
    public GameObject gameOverPanel;
   

    void Start()
    {
        gameOverPanel.SetActive(false);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

            if (other.CompareTag("Finish"))
            {
            
            if (remainingLives > 0)
                {
                    // Sonraki caný kapat
                    hearts[remainingLives - 1].gameObject.SetActive(false);
                    remainingLives--;

                    
                    if (remainingLives == 0)
                    {
                       
                        GameOver();
                    }
                }
            }
        
    }

    void GameOver()
    {

        Time.timeScale = 0f; // Oyunu durdur
        gameOverPanel.SetActive(true);
    }
    
    

    


}
