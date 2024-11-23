using System;
using UnityEngine;

public static class NumberFormatter
{
    /// <summary>
    /// ���ڸ� �� ���� (ū ���� + ���� ����)�� ����Ͽ� ǥ���մϴ�.
    /// </summary>
    /// <param name="value">������ ����</param>
    /// <returns>���� ���ڿ�</returns>
    public static string FormatLargeNumberWithTwoUnits(decimal value)
    { 
        // ���� �迭: ų��(K)���� ��Ÿ(Y)����
        string[] units = { "", "K", "M", "G", "T", "P", "E", "Z", "Y" };
        int unitIndex = 0;

        // 1000 ������ �����鼭 ū ������ ���
        while (value >= 1000 && unitIndex < units.Length - 1)
        {
            value /= 1000;
            unitIndex++;
        }

        // ū ���� ��� (���� �κ�)
        decimal majorValue = Math.Floor(value);

        // ���� ���� ��� (�Ҽ� �κ�)
        decimal remainder = value - majorValue;  // �Ҽ� �κ�
        decimal minorValue = Math.Floor(remainder * 1000);  // �Ҽ����� 1000��� Ȯ���ؼ� ���� ���� ���

        // ��� ��ȯ: ū ���� + ���� ����
        if (minorValue > 0 && unitIndex > 0) // unitIndex�� 0���� ū ��쿡�� ���� ������ ǥ��
            return $"{majorValue}{units[unitIndex]} {minorValue}{units[unitIndex - 1]}";
        else
            return $"{majorValue}{units[unitIndex]}";
    }

    /// <summary>
    ///  ���ڸ� ū ������ ����Ͽ� ǥ���մϴ�.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FormatLargeNumberWithUnits(decimal value)
    {
        // ���� �迭: ų��(K)���� ��Ÿ(Y)����
        string[] units = { "", "K", "M", "G", "T", "P", "E", "Z", "Y" };
        int unitIndex = 0;

        // 1000 ������ �����鼭 ū ������ ���
        while (value >= 1000 && unitIndex < units.Length - 1)
        {
            value /= 1000;
            unitIndex++;
        }

        // ū ���� ��� (���� �κ�)
        decimal majorValue = Math.Floor(value);

        // ���� ���� ��� (�Ҽ� �κ�)
        decimal remainder = value - majorValue;  // �Ҽ� �κ�
        decimal minorValue = Math.Floor(remainder * 1000);  // �Ҽ����� 1000��� Ȯ���ؼ� ���� ���� ���

        // ��� ��ȯ: ū ���� + ���� ����
        return $"{majorValue}{units[unitIndex]}";
    }

}
