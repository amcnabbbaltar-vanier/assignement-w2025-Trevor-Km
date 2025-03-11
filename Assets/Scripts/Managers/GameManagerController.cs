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
        DontDestroyOnLoad(this);
        
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

public void QuitGame(){
    Debug.Log("Game has been exited");
    GameObject player = GameObject.Find("Player");
    Destroy(this);
    Destroy(player);
    SceneManager.LoadScene(0);
    
}

}
