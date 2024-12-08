using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] GameObject CurrentDuck;
    [SerializeField] GameObject NewDuckCanvas;
    [SerializeField] RawImage NewDuckImage;
    [SerializeField] TextMeshProUGUI NewDuckText;

    public Sprite[] DuckImage;

    private void Start()
    {
        if (DataInfo.Instance.CurrentDuckCount == 0)
            SpawnDuck();
    }

    public void SpawnDuck()
    {

        GameObject crDuck = null;
        if (DataInfo.Instance.CurrentFeedCount <= 0)
        {
            Debug.Log("���̰� �����ϴ�!");
            return;
        }



        if (DataInfo.Instance.CurrentDuckCount < DataInfo.Instance.MaxDuckCount)
        {
            DataInfo.Instance.CurrentDuckCount++;
            crDuck = ObjectPoolManager.Instance.SpawnFromPool(CurrentDuck.name);
            crDuck.GetComponent<SpriteRenderer>().sprite = DuckImage[DataInfo.Instance.SpawnDuckLevel];
            crDuck.GetComponent<Duck>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
            DataInfo.Instance.CurrentFeedCount--;
        }
        else
        {
            Debug.LogError("��á��!");
            return;
        }

        if (crDuck == null)
        {
            Debug.LogError("���� �̻���");
        }

        float lv = crDuck.GetComponent<Duck>().nextDuck * 1f;
        int ClickCoint = (int)Mathf.Pow(1.5f, lv + 1);
        DataInfo.Instance.ClickDuckCoin += ClickCoint;
        DataInfo.Instance.PerSecondCoin += ClickCoint * 2;

        DataInfo.Instance.AllDataRoading();

    }

    public void UpgradeDuck()
    {
        if (DataInfo.Instance.CoinCount < DataInfo.Instance.SpawnDuckCost)
            return;
        DataInfo.Instance.CoinCount -= DataInfo.Instance.SpawnDuckCost;

        if (DataInfo.Instance.NewDucklevel > DataInfo.Instance.SpawnDuckLevel)
        {
            DataInfo.Instance.SpawnDuckLevel++;
        }
        else
        {
            Debug.Log(" ���� �ռ��� ���� ���� �ܰ��Դϴ�.");
        }
        DataInfo.Instance.AllDataRoading();
    }

    public void ChangeCanvas()
    {
        NewDuckImage.texture = DuckImage[DataInfo.Instance.NewDucklevel].texture;
        NewDuckText.text = $"'{DuckImage[DataInfo.Instance.NewDucklevel].name}'�� �߰��ߴ�!";
        NewDuckCanvas.SetActive(true);

        DataInfo.Instance.AllDataRoading();
    }

    //���� ���׷��̵�
    public void UpgradeFeedTime()
    {
        if (DataInfo.Instance.CoinCount < DataInfo.Instance.FeedTimeCost)
            return;
        DataInfo.Instance.CoinCount -= DataInfo.Instance.FeedTimeCost;
        DataInfo.Instance.delayTime = 10 - (DataInfo.Instance.FeedTimeLevel * 0.3f);
        DataInfo.Instance.FeedTimeLevel++;

        DataInfo.Instance.AllDataRoading();
    }
    public void UpgradeDuckCount()
    {
        if (DataInfo.Instance.CoinCount < DataInfo.Instance.DuckCountCost)
            return;
        DataInfo.Instance.CoinCount -= DataInfo.Instance.DuckCountCost;
        DataInfo.Instance.DuckCountLevel++;
        DataInfo.Instance.MaxDuckCount ++;

        DataInfo.Instance.AllDataRoading();
    }

    public void UpgradeFeedCount()
    {
        if (DataInfo.Instance.CoinCount < DataInfo.Instance.FeedCountCost)
            return;
        DataInfo.Instance.CoinCount -= DataInfo.Instance.FeedCountCost;
        DataInfo.Instance.FeedCountLevel++;
        DataInfo.Instance.MaxFeedCount ++;

        DataInfo.Instance.AllDataRoading();
    }

}
