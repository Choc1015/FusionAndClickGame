using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerSecondTime : MonoBehaviour, IUpdatable
{
    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
    }
    
    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }
    public float currentTime = 0f;

    public void OnUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 1)
        {
            DataInfo.Instance.CoinCount += (decimal)DataInfo.Instance.PerSecondCoin;
            currentTime = 0f;

            DataInfo.Instance.AllDataRoading();
        }
    }

}
