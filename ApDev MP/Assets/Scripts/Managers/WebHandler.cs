using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.UI;

public class WebHandler : MonoBehaviour
{
    public Text text;
    public string BaseURL
    {
        get { return "https://my-user-scoreboard.herokuapp.com/api/"; }
    }

    public void CreateGroup()
    {
        Debug.Log("Creating Group");
        StartCoroutine(SamplePostRoutine());
    }

    IEnumerator SamplePostRoutine()
    {
        Dictionary<string, string> PlayerParams = new Dictionary<string, string>();

        PlayerParams.Add("group_num", "10");
        PlayerParams.Add("group_name", "SF devs");
        PlayerParams.Add("game_name", "SpaceOut");

        string requestString = JsonConvert.SerializeObject(PlayerParams);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest request = new UnityWebRequest(BaseURL + "groups", "POST");

        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(requestData);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Responce Code: { request.responseCode}");
        if (string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Message: {request.downloadHandler.text}");
        }
        else
        {
            Debug.LogError($"Error:{request.error}");
        }
    }

    IEnumerator SampleGetPlayersRoutine()
    {
        UnityWebRequest request = new UnityWebRequest(BaseURL + "scores/10", "GET");

        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Response Code: {request.responseCode}");

        if(string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Message: {request.downloadHandler.text}");

            List<Dictionary<string, string>> playersList = JsonConvert.DeserializeObject<
                                                        List<Dictionary<string, string>>
                                                        >(request.downloadHandler.text);

            foreach(Dictionary<string, string> player in playersList)
            {
                Debug.Log($"Got player: {player["nickname"]}");
                text.text += $"{player["nickname"]}\n";
            }
        }
        else
        {
            Debug.LogError($"Error: {request.error}");
        }
    }
    public void GetPlayers()
    {
        StartCoroutine(SampleGetPlayersRoutine());
    }

    IEnumerator SampleGetPlayerRoutine()
    {
        UnityWebRequest request = new UnityWebRequest(BaseURL + "player/22", "GET");

        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Response Code: {request.responseCode}");

        if(string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Message: {request.downloadHandler.text}");

            Dictionary<string, string> player = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.downloadHandler.text);

            Debug.Log($"Got player: {player["nickname"]}");
        }
        else
        {
            Debug.Log($"Error: {request.error}");
        }
    }
}