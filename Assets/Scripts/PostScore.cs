using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ScoreData
{
    public string player_name;
    public string score; // Use string or int depending on your requirements
}

public class PostScore : MonoBehaviour
{
    string baseUrl = "192.168.1.26";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PostRequest($"http://{baseUrl}:5001/submit-score"));
    }

    IEnumerator PostRequest(string uri)
    {
        // Create your data object and convert it to JSON
        var data = new ScoreData { player_name = "value1", score = "value2" };
        string jsonData = JsonUtility.ToJson(data);

        // Create UnityWebRequest
        using (UnityWebRequest webRequest = new UnityWebRequest(uri, "POST"))
        {
            byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            // Set headers
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Send the request
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {webRequest.result}");
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                Debug.Log($"Response: {response}");
            }
        }
    }
}

