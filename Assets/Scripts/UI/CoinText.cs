using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    private void OnEnable()
    {
        coinText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(decimal.Parse(PlayerPrefs.GetString("Coin")))}";
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
      private void ViewText(object sender, EventArgs eventArgs)
    {
        DataInfo.Instance.SaveCoin();
        coinText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(decimal.Parse(PlayerPrefs.GetString("Coin")))}";
    }
}
