using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyHelper : MonoBehaviour
{
    private DontDestroyHelper Instance;

    void Awake(){
        if(Instance == null){
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
      
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            Destroy(gameObject);
        }
    }
}
