using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            switch(SceneManager.GetActiveScene().buildIndex){
                case 1: SceneManager.LoadScene(2);
                    break;
                case 2: SceneManager.LoadScene(3);
                    break;
            }
        }
    }
}
