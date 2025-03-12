using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalTimeController : MonoBehaviour
{
    
   [SerializeField] TMP_Text finalTimeDisplay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalTimeDisplay.text = $"Final time: {(int) TimeController.time}s";
    }
}
