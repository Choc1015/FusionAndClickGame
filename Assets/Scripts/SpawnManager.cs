using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] GameObject CurrentDuckCount;
    [SerializeField] GameObject NewDuckCanvas;
    [SerializeField] RawImage NewDuckImage;
    [SerializeField] Text NewDuckText;

    public Sprite[] DuckImage;

    public void SpawnDuck()
    {
        if (DataInfo.Instance.CurrentFeedCount <= 0)
        {
            Debug.Log("먹이가 없습니다!");
            return;
        }

        if (DataInfo.Instance.CurrentDuckCount < DataInfo.Instance.MaxDuckCount )
        {
            DataInfo.Instance.CurrentDuckCount++;
            ObjectPoolManager.Instance.SpawnFromPool(CurrentDuckCount.name);
            DataInfo.Instance.CurrentFeedCount--;
        }

    }

    public void ChangeSprite()
    {
        DataInfo.Instance.SpawnDuckLevel++;
    }

    public void ChangeCanvas()
    {
        NewDuckImage.texture = DuckImage[DataInfo.Instance.NewDucklevel].texture;
        NewDuckText.text = DuckImage[DataInfo.Instance.NewDucklevel].name + "!!";
        NewDuckCanvas.SetActive(true);
    }

    public void UpgradeFeed()
    {
        DataInfo.Instance.delayTime = 10 - (DataInfo.Instance.FeedTimeLevel * 0.3f);
        DataInfo.Instance.FeedTimeLevel++;
    }
}
