using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
 public Button playButton;
    public Sprite playButtonSprite;
    public Sprite playButtonHoverSprite;


    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(LoadGame);
    }

    // Update is called once per frame
    void Update()
    {
   
    }


   void LoadGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }

    public void OnPointerEnter(PointerEventData eventData){
        playButton.image.sprite = playButtonHoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData){
        playButton.image.sprite = playButtonSprite;
    }

}
