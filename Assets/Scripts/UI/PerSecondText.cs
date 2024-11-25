using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerSecondText : MonoBehaviour, IUpdatable
{
    private TextMeshProUGUI PerSCoinText;

    private void Awake()
    {
        PerSCoinText = GetComponent<TextMeshProUGUI>();
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
        PerSCoinText.text = $"+ {NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.PerSecondCoin)}";
    }
}
