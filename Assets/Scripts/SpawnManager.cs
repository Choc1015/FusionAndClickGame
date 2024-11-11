using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] CurrentDuck;

    private int SpawnDuckLevel = 0; // ������ �ö󰡾��Ұ�.

    public void SpawnDuck()
    {
        ObjectPoolManager.Instance.SpawnFromPool(CurrentDuck[SpawnDuckLevel].name);
    }

}
