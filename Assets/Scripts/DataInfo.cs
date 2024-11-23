using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DataInfo : Singleton<DataInfo>
{
    // 코인
    public decimal CoinCount = 0;
    // 소환 오리 레벨
    public int SpawnDuckLevel = 0;
    // 먹이 시간 감소 레벨
    public int FeedTimeLevel = 1;
    // 다음 오리 레벨
    public int NewDucklevel = 0;

    public int MaxDuckCount = 8;
    public int CurrentDuckCount = 0;

    public int MaxFeedCount = 5;
    public int CurrentFeedCount = 5;

    public float delayTime = 10f;


    public string ClickDuckCoinString = "0"; // string으로 변환하여 표시
    public string PerSecondCoinString = "0"; // string으로 변환하여 표시

    // Inspector에서 ClickDuckCoin을 보기 위한 프로퍼티
    public decimal ClickDuckCoin
    {
        get
        {
            // string을 decimal 변환하여 반환
            return decimal.Parse(ClickDuckCoinString);
        }
        set
        {
            // decimal 값을 string으로 저장
            ClickDuckCoinString = value.ToString();
        }
    }
    public decimal PerSecondCoin
    {
        get
        {
            // string을 BigInteger로 변환하여 반환
            return decimal.Parse(PerSecondCoinString);
        }
        set
        {
            // decimal 값을 string으로 저장
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
