using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    
    public Slider healthBar;
    // Start is called before the first frame update

    void Awake(){
        DontDestroyOnLoad(this);
    }
    void Start()
    {
     currentHealth = maxHealth;
     healthBar.maxValue = maxHealth;
     healthBar.value = currentHealth;
    }

    void Update(){
        healthBar.value = currentHealth;
        if(currentHealth == 0){
            TransitionToGameOver();
        }
    }


    public void TakeDamage(){
        currentHealth -= 1;
    }

    public void TransitionToGameOver(){
        GameObject gameManager = GameObject.Find("GameManager");
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("Camera"));
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("EventSystem"));        
                    
        gameManager.GetComponent<GameManagerController>().RestartGame();
        currentHealth = maxHealth;
        ScoreController.score = 0;
        gameObject.transform.position = new Vector3(0,0,0);
    }

    
}
