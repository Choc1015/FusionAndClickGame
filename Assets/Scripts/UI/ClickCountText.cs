using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickCountText : MonoBehaviour, IUpdatable
{
    private TextMeshProUGUI ClickCoinText;

    private void Awake()
    {
        ClickCoinText = GetComponent<TextMeshProUGUI>();
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
        ClickCoinText.text = $"+ {NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.ClickDuckCoin)}";
    }
}
