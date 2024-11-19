using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckCountText : MonoBehaviour, IUpdatable
{
    private Text duckCountText;

    private void Awake()
    {
        duckCountText = GetComponent<Text>();   
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
        duckCountText.text = $"{DataInfo.Instance.CurrentDuck}/{DataInfo.Instance.MaxDuckCount}";
    }
}
