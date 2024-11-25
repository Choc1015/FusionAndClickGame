using System;
using System.Collections.Generic;
using System.Linq;
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

    public int DuckCountLevel = 0;
    public int FeedCountLevel = 0;

    public int MaxDuckCount = 8;
    public int CurrentDuckCount = 0;

    public int MaxFeedCount = 5;
    public int CurrentFeedCount = 5;

    public float delayTime = 10f;

    public bool IsGame { get; set; }

    public string ClickDuckCoinString = "0"; // string으로 변환하여 표시
    public string PerSecondCoinString = "0"; // string으로 변환하여 표시

    public static List<Duck> duckList = new List<Duck>();

    public decimal SpawnDuckCost = 0;
    public decimal FeedTimeCost = 0;
    public decimal DuckCountCost = 0;
    public decimal FeedCountCost = 0;



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
        //ResetData();
        duckList = DataInfo.Instance.LoadDuckData();
        LoadData();
    }

    private void Update()
    {
        SaveData();
        LoadData();

        SpawnDuckCost = (decimal)(Math.Pow(2.5,DataInfo.Instance.SpawnDuckLevel) * 10000);
        FeedTimeCost = (decimal)Math.Pow(10, (0.373f * (DataInfo.Instance.FeedTimeLevel-1)) + 2);
        DuckCountCost = (decimal)Math.Pow(10, (0.358f * (DataInfo.Instance.DuckCountLevel)) + 2);
        FeedCountCost = (decimal)Math.Pow(10, (0.587f * (DataInfo.Instance.FeedCountLevel)) + 2);

    }

    public void SaveData()
    {
        PlayerPrefs.SetString("CoinCount", CoinCount.ToString());
        PlayerPrefs.SetInt("SpawnDuckLevel", SpawnDuckLevel);
        PlayerPrefs.SetInt("FeedTimeLevel", FeedTimeLevel);
        PlayerPrefs.SetInt("NewDucklevel", NewDucklevel);
        PlayerPrefs.SetInt("DuckCountLevel", DuckCountLevel);
        PlayerPrefs.SetInt("FeedCountLevel", FeedCountLevel);
        PlayerPrefs.SetInt("MaxDuckCount", MaxDuckCount);
        PlayerPrefs.SetInt("CurrentDuckCount", CurrentDuckCount);
        PlayerPrefs.SetInt("MaxFeedCount", MaxFeedCount);
        PlayerPrefs.SetInt("CurrentFeedCount", CurrentFeedCount);
        PlayerPrefs.SetFloat("DelayTime", delayTime);
        PlayerPrefs.SetString("ClickDuckCoinString", ClickDuckCoinString);
        PlayerPrefs.SetString("PerSecondCoinString", PerSecondCoinString);

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        CoinCount = decimal.Parse(PlayerPrefs.GetString("CoinCount", "0"));
        SpawnDuckLevel = PlayerPrefs.GetInt("SpawnDuckLevel", 0);
        FeedTimeLevel = PlayerPrefs.GetInt("FeedTimeLevel", 1);
        NewDucklevel = PlayerPrefs.GetInt("NewDucklevel", 0);
        DuckCountLevel = PlayerPrefs.GetInt("DuckCountLevel", 0);
        FeedCountLevel = PlayerPrefs.GetInt("FeedCountLevel", 0);
        MaxDuckCount = PlayerPrefs.GetInt("MaxDuckCount", 8);
        CurrentDuckCount = PlayerPrefs.GetInt("CurrentDuckCount", 0);
        MaxFeedCount = PlayerPrefs.GetInt("MaxFeedCount", 5);
        CurrentFeedCount = PlayerPrefs.GetInt("CurrentFeedCount", 5);
        delayTime = PlayerPrefs.GetFloat("DelayTime", 10f);
        ClickDuckCoinString = PlayerPrefs.GetString("ClickDuckCoinString", "0");
        PerSecondCoinString = PlayerPrefs.GetString("PerSecondCoinString", "0");
    }

    private void OnApplicationQuit()
    {
        SaveData(); // 게임 종료 시 데이터 저장
    }

    public static void SaveDuck()
    {
        duckList = FindObjectsOfType<Duck>().ToList();
        DataInfo.Instance.SaveDuckData(duckList);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData(); // 앱이 일시 정지되었을 때 데이터 저장
        }
    }
    public void ResetData()
    {
        // 기본값으로 데이터 초기화
        CoinCount = 0;
        SpawnDuckLevel = 0;
        FeedTimeLevel = 1;
        NewDucklevel = 0;
        DuckCountLevel = 1;
        FeedCountLevel = 1;
        MaxDuckCount = 8;
        CurrentDuckCount = 0;
        MaxFeedCount = 5;
        CurrentFeedCount = 5;
        delayTime = 10f;
        ClickDuckCoinString = "0";
        PerSecondCoinString = "0";

        // PlayerPrefs 데이터도 초기화
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("모든 데이터가 초기화되었습니다.");
    }

    public void SaveDuckData(List<Duck> ducks)
    {
        List<DuckData> duckDataList = new List<DuckData>();

        foreach (var duck in ducks)
        {
            DuckData data = new DuckData
            {
                NextDuck = duck.nextDuck,
                SpriteName = duck.GetComponent<SpriteRenderer>().sprite.name,
                Position = duck.transform.position
            };
            duckDataList.Add(data);
        }

        string json = JsonUtility.ToJson(new DuckDataWrapper { Ducks = duckDataList });
        PlayerPrefs.SetString("DuckData", json);
        PlayerPrefs.SetInt("CurrentDuckCount", ducks.Count);
        PlayerPrefs.Save();

        Debug.Log("Duck data saved: " + json);
    }

    [System.Serializable]
    private class DuckDataWrapper
    {
        public List<DuckData> Ducks;
    }

    public List<Duck> LoadDuckData()
    {
        string json = PlayerPrefs.GetString("DuckData", "");
        if (string.IsNullOrEmpty(json))
        {
            Debug.Log("No saved duck data found.");
            return new List<Duck>();
        }

        DuckDataWrapper wrapper = JsonUtility.FromJson<DuckDataWrapper>(json);
        List<DuckData> duckDataList = wrapper.Ducks;

        List<Duck> ducks = new List<Duck>();

        foreach (var data in duckDataList)
        {
            GameObject duckObj = ObjectPoolManager.Instance.SpawnFromPool("Duck");
            Duck duck = duckObj.GetComponent<Duck>();

            // Duck 상태 복원
            duck.nextDuck = data.NextDuck;
            duckObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Sprites/{data.SpriteName}");
            duckObj.transform.position = data.Position;

            ducks.Add(duck);
        }

        DataInfo.Instance.CurrentDuckCount = ducks.Count;
        Debug.Log("Duck data loaded.");

        return ducks;
    }

}
