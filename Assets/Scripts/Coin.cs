using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public void OnGetCoin()
    {
        AudioManager.Instance.PlayCointSound();
        DataInfo.Instance.CoinCount += DataInfo.Instance.ClickDuckCoin;
    }

}
