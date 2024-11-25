using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public void OnGetCoin()
    {
        DataInfo.Instance.CoinCount += DataInfo.Instance.ClickDuckCoin;
    }

}
