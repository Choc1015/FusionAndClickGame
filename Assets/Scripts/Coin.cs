using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    private int coinCount;
    public static event EventHandler OnClikButton;
    
    private void Awake()
    {
        coinCount = DataInfo.Instance.CointCount; 
    }

    public void OnGetCoin()
    {
        coinCount++;
        DataInfo.Instance.CointCount = coinCount;

        OnClikButton?.Invoke(this, EventArgs.Empty);
    }

}
