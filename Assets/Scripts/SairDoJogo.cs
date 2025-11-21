using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SairDoJogo : MonoBehaviour
{
    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        // Fecha o aplicativo compilado
        Application.Quit();

    }
}