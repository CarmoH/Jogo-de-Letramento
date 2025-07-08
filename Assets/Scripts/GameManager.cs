using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score = 5;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
        UpdateScoreText();
    }

    public void SubtractScore(int value)
    {
        score -= value;
        if (score < 0) score = 0; // Evita valores negativos, se quiser
        UpdateScoreText();
        if (score == 0)
        {
            PlayerPrefs.SetString("UltimaFase", SceneManager.GetActiveScene().name); //salva os dados
            SceneManager.LoadScene("FimDeJogo");
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}
