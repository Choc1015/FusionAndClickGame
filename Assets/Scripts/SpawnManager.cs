using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] CurrentDuck;

    private int SpawnDuckLevel = 0; // 서버에 올라가야할것.

    public void SpawnDuck()
    {
        ObjectPoolManager.Instance.SpawnFromPool(CurrentDuck[SpawnDuckLevel].name);
    }

}
