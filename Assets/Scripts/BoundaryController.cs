using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            GameObject gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManagerController>().ResetLevel();
        }
    }

}
