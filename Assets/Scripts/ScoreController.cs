using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    public TMP_Text scoreDisplay;
    void Awake(){
        score = 0;
        DontDestroyOnLoad(this);
    }


    void Update(){
        UpdateScore();
    }

    void incrementScore(){
        score++;
    }

    void UpdateScore(){
    
    scoreDisplay.text = $"Score: {score}";
    }

}
