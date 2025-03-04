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

    public TextMeshProUGUI SpawnDuckLevel;
    public TextMeshProUGUI FeedTimeLevel;
    public TextMeshProUGUI DuckCountLevel;
    public TextMeshProUGUI FeedCountLevel;

    public TextMeshProUGUI SDNLevel;
    public TextMeshProUGUI FTLevel;
    public TextMeshProUGUI DCLevel;
    public TextMeshProUGUI FCLevel;


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
        SpawnDuckCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.SpawnDuckCost)}";
        FeedTimeCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.FeedTimeCost)}";
        DuckCountCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.DuckCountCost)}";
        FeedCountCostText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(DataInfo.Instance.FeedCountCost)}";

        SpawnDuckLevel.text = $"LV.{DataInfo.Instance.SpawnDuckLevel}";
        FeedTimeLevel.text = $"LV.{DataInfo.Instance.FeedTimeLevel - 1}";
        DuckCountLevel.text = $"LV.{DataInfo.Instance.DuckCountLevel}";
        FeedCountLevel.text = $"LV.{DataInfo.Instance.FeedCountLevel}";

        SDNLevel.text = $"积己 坷府 {DataInfo.Instance.SpawnDuckLevel} -> {DataInfo.Instance.SpawnDuckLevel + 1}";
        FTLevel.text = $"积己 坷府 {DataInfo.Instance.FeedTimeLevel - 1}s -> {DataInfo.Instance.FeedTimeLevel}s";
        DCLevel.text = $"积己 坷府 {DataInfo.Instance.DuckCountLevel} -> {DataInfo.Instance.DuckCountLevel + 1}";
        FCLevel.text = $"积己 坷府 {DataInfo.Instance.FeedCountLevel} -> {DataInfo.Instance.FeedCountLevel + 1}";

    }

    /*
     * 
     * \n{DataInfo.Instance.SpawnDuckLevel} 饭骇
     * \n{DataInfo.Instance.FeedTimeLevel - 1} 饭骇
     * \n{DataInfo.Instance.DuckCountLevel} 饭骇
     * \n{DataInfo.Instance.FeedCountLevel} 饭骇
     * 
     */

}
