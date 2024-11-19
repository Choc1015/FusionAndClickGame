using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedCountText : MonoBehaviour,IUpdatable
{
    private Text duckFeedText;

    private void Awake()
    {
        duckFeedText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    public void OnUpdate()
    {
        duckFeedText.text = $"{DataInfo.Instance.CurrentFeedCount}/{DataInfo.Instance.MaxFeedCount}";
    }
}
