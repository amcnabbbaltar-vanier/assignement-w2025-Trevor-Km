using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: Implement traps, levels
public class TimeController : MonoBehaviour
{
   public float time = 0f; // Start is called before the first frame update

   TMP_Text timeDisplay;
    
    void Awake(){
        timeDisplay = GetComponent<TMP_Text>();
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0){
            time += Time.deltaTime;
        }else{
            time = 0;
        }
        timeDisplay.text = $"Time: {(int) time}";
    }
}
