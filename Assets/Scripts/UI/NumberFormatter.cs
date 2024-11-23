using System;
using UnityEngine;

public static class NumberFormatter
{
    /// <summary>
    /// 숫자를 두 단위 (큰 단위 + 작은 단위)로 축약하여 표시합니다.
    /// </summary>
    /// <param name="value">포맷할 숫자</param>
    /// <returns>축약된 문자열</returns>
    public static string FormatLargeNumberWithTwoUnits(decimal value)
    { 
        // 단위 배열: 킬로(K)부터 요타(Y)까지
        string[] units = { "", "K", "M", "G", "T", "P", "E", "Z", "Y" };
        int unitIndex = 0;

        // 1000 단위로 나누면서 큰 단위를 계산
        while (value >= 1000 && unitIndex < units.Length - 1)
        {
            value /= 1000;
            unitIndex++;
        }

        // 큰 단위 계산 (정수 부분)
        decimal majorValue = Math.Floor(value);

        // 작은 단위 계산 (소수 부분)
        decimal remainder = value - majorValue;  // 소수 부분
        decimal minorValue = Math.Floor(remainder * 1000);  // 소수점을 1000배로 확대해서 작은 단위 계산

        // 결과 반환: 큰 단위 + 작은 단위
        if (minorValue > 0 && unitIndex > 0) // unitIndex가 0보다 큰 경우에만 작은 단위를 표시
            return $"{majorValue}{units[unitIndex]} {minorValue}{units[unitIndex - 1]}";
        else
            return $"{majorValue}{units[unitIndex]}";
    }

    /// <summary>
    ///  숫자를 큰 단위로 축약하여 표시합니다.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FormatLargeNumberWithUnits(decimal value)
    {
        // 단위 배열: 킬로(K)부터 요타(Y)까지
        string[] units = { "", "K", "M", "G", "T", "P", "E", "Z", "Y" };
        int unitIndex = 0;

        // 1000 단위로 나누면서 큰 단위를 계산
        while (value >= 1000 && unitIndex < units.Length - 1)
        {
            value /= 1000;
            unitIndex++;
        }

        // 큰 단위 계산 (정수 부분)
        decimal majorValue = Math.Floor(value);

        // 작은 단위 계산 (소수 부분)
        decimal remainder = value - majorValue;  // 소수 부분
        decimal minorValue = Math.Floor(remainder * 1000);  // 소수점을 1000배로 확대해서 작은 단위 계산

        // 결과 반환: 큰 단위 + 작은 단위
        return $"{majorValue}{units[unitIndex]}";
    }

}
