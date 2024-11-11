using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public static event EventHandler OnClikButton;
    

    private void Start()
    {
        OnClikButton?.Invoke(this, EventArgs.Empty);
    }

    public void OnGetCoin()
    {
        DataInfo.Instance.CoinCount++;
        
        OnClikButton?.Invoke(this, EventArgs.Empty);
    }

}
