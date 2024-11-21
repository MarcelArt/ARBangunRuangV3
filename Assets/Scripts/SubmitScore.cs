using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SubmitScore : MonoBehaviour
{
    public TMP_InputField nameInputField; // Input field untuk nama
    public TMP_Text playerNameText;        // Text untuk menampilkan nama pemain
    public TMP_Text scoreText;             // Text untuk menampilkan skor

    private int currentScore;              // Menyimpan skor saat ini

    private void Start()
    {
        // Ambil skor dari PlayerPrefs
        currentScore = PlayerPrefs.GetInt("PlayerScore", 0);

        // Tampilkan skor saat ini di UI
        scoreText.text = $"Score: {currentScore}";
    }

    // Fungsi untuk menampilkan nama pemain
    public void DisplayPlayerName()
    {
        // Ambil nama dari input field
        string playerName = nameInputField.text;

        // Tampilkan nama pemain di UI
        playerNameText.text = $"Player: {playerName}";
    }

    // Fungsi untuk mengirim data ke server
    public void SubmitData()
    {
        // Ambil nama pemain dari input field
        string playerName = nameInputField.text;

        // Kirim data ke server menggunakan coroutine
        StartCoroutine(PostRequest("http://10.10.40.122:5001///submit-score", playerName, currentScore));
    }

    // Fungsi untuk mengirim request ke server
    private IEnumerator PostRequest(string uri, string playerNameInput, int playerScore)
    {
        // Buat objek data yang berisi nama dan skor pemain
        var data = new ScoreData { player_name = playerNameInput, score = playerScore.ToString() };
        string jsonData = JsonUtility.ToJson(data); // Konversi data menjadi JSON

        // Buat permintaan web
        using (UnityWebRequest webRequest = new UnityWebRequest(uri, "POST"))
        {
            byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            // Set header untuk permintaan JSON
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Kirim permintaan
            yield return webRequest.SendWebRequest();

            // Cek hasil permintaan
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                Debug.Log($"Response: {webRequest.downloadHandler.text}");
            }
        }
    }
}
