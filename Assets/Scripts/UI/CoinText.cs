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
        string coinString = PlayerPrefs.GetString("CoinCount", null); // �⺻���� null�� ����
        decimal coinValue;

        if (string.IsNullOrEmpty(coinString))
        {
            // �����Ͱ� ���� ���� �ʱ� ����
            Debug.LogWarning("CoinCount key is missing. Initializing default value.");
            coinText.text = "No Data"; // �����Ͱ� ������ UI�� ǥ��
        }
        else if (!decimal.TryParse(coinString, out coinValue))
        {
            // �����Ͱ� ������ �߸��� ������ ���
            Debug.LogError($"Invalid CoinCount format: {coinString}");
            coinText.text = "Data Error"; // �߸��� ���������� UI�� ǥ��
        }
        else
        {
            // ��ȿ�� �����Ͱ� �ִ� ���
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
