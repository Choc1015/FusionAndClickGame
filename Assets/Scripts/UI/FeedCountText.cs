using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedCountText : MonoBehaviour,IUpdatable
{
    private TextMeshProUGUI duckFeedText;

    private void Awake()
    {
        duckFeedText = GetComponent<TextMeshProUGUI>();
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
        duckFeedText.text = $"({DataInfo.Instance.CurrentFeedCount}/{DataInfo.Instance.MaxFeedCount})";
    }
}
