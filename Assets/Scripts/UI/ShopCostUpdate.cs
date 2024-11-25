using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopCostUpdate : MonoBehaviour, IUpdatable
{
    public TextMeshProUGUI SpawnDuckCostText;
    public TextMeshProUGUI FeedTimeCostText;
    public TextMeshProUGUI DuckCountCostText;
    public TextMeshProUGUI FeedCountCostText;

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
        SpawnDuckCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.SpawnDuckCost)}\n{DataInfo.Instance.SpawnDuckLevel} ����";
        FeedTimeCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.FeedTimeCost)}\n{DataInfo.Instance.FeedTimeLevel - 1} ����";
        DuckCountCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.DuckCountCost)}\n{DataInfo.Instance.DuckCountLevel} ����";
        FeedCountCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.FeedCountCost)}\n{DataInfo.Instance.FeedCountLevel} ����";
    }

}
