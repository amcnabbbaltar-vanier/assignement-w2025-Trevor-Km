using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{

    public Button restartButton;

    public Button mainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame(){
    Debug.Log("Game has been exited");
    GameObject player = GameObject.Find("Player");
    GameObject cam = GameObject.Find("Camera");
    GameObject freelook = GameObject.Find("FreeLook Camera");
    GameObject boundary = GameObject.Find("Boundary");
    Destroy(boundary);
    Destroy(gameObject);
    Destroy(cam);
    Destroy(freelook);
    Destroy(player);
    SceneManager.LoadScene(0);
}

public void RestartGame(){
    SceneManager.LoadScene(1);
    GameObject boundary = GameObject.Find("Boundary");
    Destroy(boundary);
    ScoreController.score = 0;
    TimeController.time = 0;
}
}
