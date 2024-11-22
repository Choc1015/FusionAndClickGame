using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFeed : MonoBehaviour, IUpdatable
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
        if(DataInfo.Instance.CurrentFeedCount != DataInfo.Instance.MaxFeedCount)
        currentTime += Time.deltaTime;

        if (currentTime >= DataInfo.Instance.delayTime)
        {
            if (DataInfo.Instance.CurrentFeedCount < DataInfo.Instance.MaxFeedCount)
            {
                DataInfo.Instance.CurrentFeedCount++;
                currentTime = 0f;
            }
        }
    }
}
