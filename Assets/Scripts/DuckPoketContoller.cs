using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static CanvasController;

public class DuckPoketContoller : Singleton<DuckPoketContoller>
{
    [SerializeField] TextMeshProUGUI poketText;
    [SerializeField] public Image poketImage;
    

    private Button pocketButton;

    private void Awake()
    {
        pocketButton = GetComponent<Button>();
        
    }

    private void Start()
    {
        pocketButton.interactable = false;
        pocketButton.onClick.AddListener(ClickedPokedex);
        OpenDuckImage();
    }

    private void OnEnable()
    {
        OpenDuckImage();
    }


    public void ClickedPokedex()
    {
        DuckImage duckImage = GetComponentInChildren<DuckImage>();

        foreach (duckPoket duck in PoketData.Instance.poketList)
        {
            if (duck.DuckIntIndex == duckImage.ImageNumber)
            {
                poketText.text = duck.text;
                poketImage.sprite = duckImage.GetComponent<Image>().sprite;
            }
            
        }

    }

    public void OpenDuckImage()
    {
        DuckImage duckIm = GetComponentInChildren<DuckImage>();
        Image duckImage = duckIm.GetComponent<Image>();

            if (duckIm.ImageNumber <= DataInfo.Instance.NewDucklevel)
            {
            pocketButton.interactable = true;
            duckImage.color = Color.white; 
            }
    }
}
