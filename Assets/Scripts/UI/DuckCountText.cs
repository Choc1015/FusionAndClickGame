using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckCountText : MonoBehaviour, IUpdatable
{
    private TextMeshProUGUI duckCountText;

    private void Awake()
    {
        duckCountText = GetComponent<TextMeshProUGUI>();
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
        duckCountText.text = $"{DataInfo.Instance.CurrentDuckCount} / {DataInfo.Instance.MaxDuckCount}";
    }
}
