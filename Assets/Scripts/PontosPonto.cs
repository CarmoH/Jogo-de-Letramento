using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PontosPonto : MonoBehaviour
{
    public static PontosPonto instance;

    private int score = 5;

    public TextMeshPro scoreText;
    
    public int acertos = 0;
    [SerializeField] private int totalAcertosNecessarios = 3;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
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
        if (score < 0) score = 0;

        UpdateScoreText();

        if (score == 0)
        {
            Debug.Log("Fim de jogo!");
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

