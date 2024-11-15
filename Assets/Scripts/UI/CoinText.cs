using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour, IUpdatable
{
    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        coinText.text = $"{PlayerPrefs.GetInt("Coin")}";
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    private TMP_Text coinText;

    private void Awake()
    {
        coinText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        Coin.OnClikButton -= ViewText;
        Coin.OnClikButton += ViewText;


    }
    public void OnUpdate()
    {
        //ViewText();
        
    }

    private void ViewText(object sender, EventArgs eventArgs)
    {
        DataInfo.Instance.SaveCoin();
        coinText.text = $"{PlayerPrefs.GetInt("Coin")}";
    }
}
