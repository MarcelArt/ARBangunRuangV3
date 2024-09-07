using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Soal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest() {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost:3000/comments")) {
            yield return webRequest.SendWebRequest();
            
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
                Debug.LogError($"Error: {webRequest.error}");
            } else {
                Debug.Log($"Response: {webRequest.downloadHandler.text}");
            }
        }
    }
}
