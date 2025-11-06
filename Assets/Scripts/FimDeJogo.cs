using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeJogo : MonoBehaviour
{
    public void TentarNovamente()
    {
        string faseAnterior = PlayerPrefs.GetString("UltimaFase"); //Le os dados
        if (!string.IsNullOrEmpty(faseAnterior))
        {
            SceneManager.LoadScene(faseAnterior);
        }
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
