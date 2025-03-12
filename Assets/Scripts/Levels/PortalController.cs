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
                GameObject.Find("Player").transform.position = new Vector3(0f,0f,0f);
                    break;
                case 3: SceneManager.LoadScene(4);
                    GameObject.Find("Player").transform.position = new Vector3(0f,0f,0f);
                    break;
                case 4: 
                   Destroy(GameObject.Find("Player"));
                    Destroy(GameObject.Find("Canvas"));
                    Destroy(GameObject.Find("Camera"));
                    Destroy(GameObject.Find("GameManager"));
                    Destroy(GameObject.Find("EventSystem"));
                    SceneManager.LoadScene(5);
                    break;
            }
        }
    }
}
