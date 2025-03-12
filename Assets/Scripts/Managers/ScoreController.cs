using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    public static int score;
    // Start is called before the first frame update
    public TMP_Text scoreDisplay;
    void Awake(){
        score = 0;
    }


    void Update(){
        UpdateScore();
    }

    

    void UpdateScore(){
    scoreDisplay.text = $"Score: {score}";
    }

}

