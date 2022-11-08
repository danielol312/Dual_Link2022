using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highscoreText;
    [SerializeField] int pointsPerSecond = 10;
    public float score;
    

    
    void Awake()
    {
        score = 0;
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    void Update()
    {
        score += Time.deltaTime * pointsPerSecond;
        int scoreInt = (int)score;
        scoreText.text = scoreInt.ToString();
        PlayerPrefs.SetInt("Score", scoreInt);


        if (scoreInt > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", scoreInt);
            highscoreText.text = scoreInt.ToString();
        }
        
    }
}
