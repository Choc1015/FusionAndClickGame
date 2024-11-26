using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour, IUpdatable
{
    private TMP_Text coinText;

    private void Awake()
    {
        coinText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        UpdateCoinText();
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    private void UpdateCoinText()
    {
        string coinString = PlayerPrefs.GetString("CoinCount", null); // 기본값을 null로 설정
        decimal coinValue;

        if (string.IsNullOrEmpty(coinString))
        {
            // 데이터가 전혀 없는 초기 상태
            Debug.LogWarning("CoinCount key is missing. Initializing default value.");
            coinText.text = "No Data"; // 데이터가 없음을 UI에 표시
        }
        else if (!decimal.TryParse(coinString, out coinValue))
        {
            // 데이터가 있지만 잘못된 형식인 경우
            Debug.LogError($"Invalid CoinCount format: {coinString}");
            coinText.text = "Data Error"; // 잘못된 데이터임을 UI에 표시
        }
        else
        {
            // 유효한 데이터가 있는 경우
            coinText.text = $"{NumberFormatter.FormatLargeNumberWithTwoUnits(coinValue)}";
        }
    }

    private void ViewText()
    {
        UpdateCoinText();
    }

    public void OnUpdate()
    {
        ViewText();
    }
}
