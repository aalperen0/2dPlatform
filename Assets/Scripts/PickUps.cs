using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public TMP_Text scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Coin" || collision.tag == "Different")
        {
            Scoring.totalScore++;
            scoreText.text = "SCORE: " + Scoring.totalScore;
            if (collision.tag == "Different")
            {
                Scoring.totalScore += 1;
                scoreText.text = "SCORE: " + Scoring.totalScore;
            }
            
            collision.gameObject.SetActive(false);
        }
    }

}
