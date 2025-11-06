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

    public int acertos = 0;
    [SerializeField] private int totalAcertosNecessarios = 3;


    private void Awake()
    {
        instance = this;
        UpdateScoreText();
    }


    public void AddAcerto()
    {
        acertos++;

        if (acertos >= totalAcertosNecessarios)
        {
            PlayerPrefs.SetString("UltimaFase", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("TelaVitoria");
        }
    }

    public void SubtractScore(int value)
    {
        score -= value;
        if (score < 0) score = 0; // Evita valores negativos
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
