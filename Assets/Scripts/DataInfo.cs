using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : Singleton<DataInfo>
{
    public int CoinCount = 0;
    public int SpawnDuckLevel = 0;
    public int NewDucklevel = 0;
    public int MaxDuckCount = 8;
    public int CurrentDuck = 0;

    private void Awake()
    {
        CoinCount = PlayerPrefs.GetInt("Coin");
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", CoinCount);
    }

}
