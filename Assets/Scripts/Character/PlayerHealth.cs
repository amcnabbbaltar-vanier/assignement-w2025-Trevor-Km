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
        gameManager.GetComponent<GameManagerController>().QuitGame();
    }

    
}
