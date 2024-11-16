using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] GameObject CurrentDuck;
    public Sprite[] DuckImage;
    

    public void SpawnDuck()
    {
        ObjectPoolManager.Instance.SpawnFromPool(CurrentDuck.name);
    }

    public void ChangeSprite()
    {
        DataInfo.Instance.SpawnDuckLevel++;
    }

}
