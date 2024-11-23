using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DataInfo : Singleton<DataInfo>
{
    // ����
    public decimal CoinCount = 0;
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


    public string ClickDuckCoinString = "0"; // string���� ��ȯ�Ͽ� ǥ��
    public string PerSecondCoinString = "0"; // string���� ��ȯ�Ͽ� ǥ��

    // Inspector���� ClickDuckCoin�� ���� ���� ������Ƽ
    public decimal ClickDuckCoin
    {
        get
        {
            // string�� decimal ��ȯ�Ͽ� ��ȯ
            return decimal.Parse(ClickDuckCoinString);
        }
        set
        {
            // decimal ���� string���� ����
            ClickDuckCoinString = value.ToString();
        }
    }
    public decimal PerSecondCoin
    {
        get
        {
            // string�� BigInteger�� ��ȯ�Ͽ� ��ȯ
            return decimal.Parse(PerSecondCoinString);
        }
        set
        {
            // decimal ���� string���� ����
            PerSecondCoinString = value.ToString();
        }
    }



    private void Awake()
    {

        CoinCount = decimal.Parse(PlayerPrefs.GetString("Coin"));
        //CoinCount = 0;
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetString("Coin", CoinCount.ToString());
    }

}
