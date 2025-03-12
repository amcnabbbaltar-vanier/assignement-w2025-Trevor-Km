using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    public static GameManagerController Instance;
    bool pauseState = false;
    // Start is called before the first frame update

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        if(Input.GetKeyDown(KeyCode.Escape)){
            HandlePauseGame();
        }

    }

    public void HandlePauseGame(){
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


    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenuPanel.SetActive(false);

    }

public void QuitGame(){
    Debug.Log("Game has been exited");
    GameObject player = GameObject.Find("Player");
    GameObject cam = GameObject.Find("Camera");
    GameObject freelook = GameObject.Find("FreeLook Camera");
    Destroy(gameObject);
    Destroy(cam);
    Destroy(freelook);
    Destroy(player);
    SceneManager.LoadScene(0);
    
}

}
