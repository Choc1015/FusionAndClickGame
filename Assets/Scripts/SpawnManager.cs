using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] GameObject CurrentDuck;
    [SerializeField] GameObject NewDuckCanvas;
    [SerializeField] RawImage NewDuckImage;
    [SerializeField] Text NewDuckText;

    public Sprite[] DuckImage;
    

    public void SpawnDuck()
    {
        if (DataInfo.Instance.CurrentDuck < DataInfo.Instance.MaxDuckCount )
        {
            DataInfo.Instance.CurrentDuck++;
            ObjectPoolManager.Instance.SpawnFromPool(CurrentDuck.name);
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


}
