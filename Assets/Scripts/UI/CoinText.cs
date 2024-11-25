using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour,IUpdatable
{
    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        coinText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(decimal.Parse(PlayerPrefs.GetString("Coin")))}";
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

    private void ViewText()
    {
        DataInfo.Instance.SaveCoin();
        coinText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(decimal.Parse(PlayerPrefs.GetString("Coin")))}";
    }

    public void OnUpdate()
    {
        ViewText();
    }
}
