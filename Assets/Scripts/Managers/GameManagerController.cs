using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    public static GameManagerController Instance {get; private set;}

    

    bool pauseState = false;
    // Start is called before the first frame update

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 5){
            HandlePauseGame();
        }

    }

    public void HandlePauseGame(){
        if(SceneManager.GetActiveScene().buildIndex != 5){
            if(!pauseState){
           pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
            pauseState = true;
        }else{
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1f;
            pauseState = false;
        }
        }
        
    }


    public void RestartLevel(){ 
        GameObject player = GameObject.Find("Player");
        if(SceneManager.GetActiveScene().buildIndex == 1){
            GameObject cam = GameObject.Find("Camera");
            GameObject freelook = GameObject.Find("FreeLook Camera");
            GameObject eventSystem = GameObject.Find("EventSystem");
            GameObject canvas = GameObject.Find("Canvas");
            GameObject boundary = GameObject.Find("Boundary");
            Destroy(boundary);
            Destroy(eventSystem);
            Destroy(canvas);
            Destroy(gameObject);
            Destroy(cam);
            Destroy(freelook);
            Destroy(player);
        }
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          pauseMenuPanel.SetActive(false);
          player.transform.position = new Vector3(0, 0, 0);
          Time.timeScale = 1f;
    }


    public void ResetLevel(){
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(0, 0, 0);
        player.GetComponent<PlayerHealth>().TakeDamage();
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
    Destroy(GameObject.Find("EventSystem"));   
    Destroy(player);
    SceneManager.LoadScene(0);
    
}

public void RestartGame(){
    SceneManager.LoadScene(1);
    ScoreController.score = 0;
    TimeController.time = 0;
}

}
