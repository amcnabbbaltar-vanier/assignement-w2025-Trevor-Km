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
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData){
        playButton.image.sprite = playButtonHoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData){
        playButton.image.sprite = playButtonSprite;
    }
}
