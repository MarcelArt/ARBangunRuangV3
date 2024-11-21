using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Referensi untuk TMP Text

    private void Start()
    {
        // Ambil skor dari PlayerPrefs saat scene dimulai
        int savedScore = PlayerPrefs.GetInt("PlayerScore", 0);
        UpdateScoreText(savedScore);
    }

    public void AnswerCorrect()
    {
        int currentScore = PlayerPrefs.GetInt("PlayerScore", 0);
        currentScore += 20; // Tambahkan skor
        PlayerPrefs.SetInt("PlayerScore", currentScore); // Simpan skor
        UpdateScoreText(currentScore);
    }

    public void AnswerWrong()
    {
        // Tidak menambah skor
        int currentScore = PlayerPrefs.GetInt("PlayerScore", 0);
        UpdateScoreText(currentScore);
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Method untuk reset skor (dipanggil saat game selesai)
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("PlayerScore"); // Hapus data skor
        UpdateScoreText(0); // Tampilkan skor 0
    }
}
