using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class ServerDataManager : MonoBehaviour
{
    private string saveDataUrl = "http://3.39.229.182:8000/save/1015";
    private string loadDataUrl = "http://3.39.229.182:8000/load/1015";

    // 게임 및 Duck 데이터를 저장
    public void SaveDataToServer(GameData gameData, List<DuckData> ducks)
    {
        CombinedData combinedData = new CombinedData
        {
            GameData = gameData,
            Ducks = ducks
        };

        string jsonData = JsonUtility.ToJson(combinedData);
        StartCoroutine(SendPostRequest(saveDataUrl, jsonData));
    }

    // 게임 및 Duck 데이터를 로드
    public void LoadDataFromServer(System.Action<GameData, List<DuckData>> onDataLoaded)
    {
        StartCoroutine(SendGetRequest(loadDataUrl, (json) =>
        {
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("Empty or null JSON received from server.");
                return;
            }

            try
            {
                CombinedData combinedData = JsonUtility.FromJson<CombinedData>(json);
                onDataLoaded?.Invoke(combinedData.GameData, combinedData.Ducks);
            }
            catch (Exception ex)
            {
                Debug.LogError($"JSON parsing error: {ex.Message}");
            }
        }));
    }

    private IEnumerator SendPostRequest(string url, string jsonData)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {request.error}");
            }
            else
            {
                Debug.Log($"Server Response: {request.downloadHandler.text}");
            }
        }
    }

    private IEnumerator SendGetRequest(string url, System.Action<string> onDataReceived)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {request.error}");
            }
            else
            {
                onDataReceived?.Invoke(request.downloadHandler.text);
            }
        }
    }
}

// 통합 데이터 클래스
[Serializable]
public class CombinedData
{
    public GameData GameData;
    public List<DuckData> Ducks;
}

