using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : Singleton<DataInfo>
{
    // ����
    public int CoinCount = 0;
    // ��ȯ ���� ����
    public int SpawnDuckLevel = 0;
    // ���� �ð� ���� ����
    public int FeedTimeLevel = 1;
    // ���� ���� ����
    public int NewDucklevel = 0;

    public int MaxDuckCount = 8;
    public int CurrentDuckCount = 0;

    public int MaxFeedCount = 5;
    public int CurrentFeedCount = 5;

    public float delayTime = 10f;

    public int ClickDuckCoin = 0;
    public int PerSecondCoin = 0;


    private void Awake()
    {
        CoinCount = PlayerPrefs.GetInt("Coin");
        //CoinCount = 0;
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", CoinCount);
    }

}
