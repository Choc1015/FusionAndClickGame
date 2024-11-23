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

       

        if (DataInfo.Instance.CurrentDuckCount < DataInfo.Instance.MaxDuckCount )
        {
            DataInfo.Instance.CurrentDuckCount++;
            crDuck = ObjectPoolManager.Instance.SpawnFromPool(CurrentDuck.name);
            DataInfo.Instance.CurrentFeedCount--;
        }
        else
        {
            Debug.LogError("��á��!");
            return;
        }

        if(crDuck == null)
        {
            Debug.LogError("���� �̻���");
        }

        float lv = crDuck.GetComponent<Duck>().nextDuck * 1f;
        int ClickCoint = (int)Mathf.Pow(1.5f, lv + 1);
        DataInfo.Instance.ClickDuckCoin += ClickCoint;
        DataInfo.Instance.PerSecondCoin += ClickCoint * 2;


    }

    public void ChangeSprite()
    {
        if(DataInfo.Instance.NewDucklevel > DataInfo.Instance.SpawnDuckLevel)
        {
            DataInfo.Instance.SpawnDuckLevel++;
        }
        else
        {
            Debug.Log(" ���� �ռ��� ���� ���� �ܰ��Դϴ�.");
        }
    }

    public void ChangeCanvas()
    {
        NewDuckImage.texture = DuckImage[DataInfo.Instance.NewDucklevel].texture;
        NewDuckText.text = $"'{DuckImage[DataInfo.Instance.NewDucklevel].name}'�� �߰��ߴ�!";
        NewDuckCanvas.SetActive(true);
    }

    public void UpgradeFeed()
    {
        DataInfo.Instance.delayTime = 10 - (DataInfo.Instance.FeedTimeLevel * 0.3f);
        DataInfo.Instance.FeedTimeLevel++;
    }
}
