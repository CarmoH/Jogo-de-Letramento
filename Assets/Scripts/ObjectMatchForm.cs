using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectMatchForm : MonoBehaviour
{
    [SerializeField] private int valoresIguais;

    public int pegar_valores()
    {
        return valoresIguais;
    }
}
