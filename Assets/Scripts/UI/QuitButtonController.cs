using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class QuitButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
 public Button playButton;
    public Sprite playButtonSprite;
    public Sprite playButtonHoverSprite;


    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.Find("MenuQuitButton").GetComponent<Button>();
        playButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void ExitGame(){
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData){
        playButton.image.sprite = playButtonHoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData){
        playButton.image.sprite = playButtonSprite;
    }

}
