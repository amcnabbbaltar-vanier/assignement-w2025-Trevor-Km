using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button playButton;
    public Sprite playButtonSprite;
    public Sprite playButtonHoverSprite;


    // Start is called before the first frame update
    void Start()
    {
       GameObject player = GameObject.Find("Player");
       GameObject gameManager = GameObject.Find("GameManager");
       gameManager.GetComponent<TimeController>().time = 0f;
       Destroy(player);
       Destroy(gameManager);
       playButton = GameObject.Find("PlayButton").GetComponent<Button>();

    }


    public void OnPointerEnter(PointerEventData eventData){
        playButton.image.sprite = playButtonHoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData){
        playButton.image.sprite = playButtonSprite;
    }
}
