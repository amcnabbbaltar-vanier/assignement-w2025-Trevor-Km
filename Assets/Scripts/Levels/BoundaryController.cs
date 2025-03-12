using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryController : MonoBehaviour
{
    private BoundaryController Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
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
