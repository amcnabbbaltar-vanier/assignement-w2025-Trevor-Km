using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScoreController : MonoBehaviour
{
   [SerializeField] TMP_Text finalScoreDisplay;
    ScoreController finalScore;

    void Awake(){
        finalScoreDisplay.text = $"Final Score: {ScoreController.score}";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
