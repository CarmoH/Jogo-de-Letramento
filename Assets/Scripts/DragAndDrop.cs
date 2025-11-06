using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rt; //referencia componentes
    private CanvasGroup grupo; //permite controlar a opacidade (alpha) e se o objeto bloqueia interações.

    private Vector2 posicaoOriginal; //Vai guarda a posição original do Objeto

    public bool foiDropValido = false; //Verificar se o objeto foi dropado no Drop

    private void Start()
    {
        posicaoOriginal = rt.anchoredPosition; //guarda a posição original
    }
    private void Awake() //chamado automaticamente antes de Start(), quando o objeto é instanciado
    {
        rt = GetComponent<RectTransform>(); //Pega o componente RectTransform do GameObject ao qual o script está anexado.
        grupo = GetComponent<CanvasGroup>(); //Pega o CanvasGroup para permitir alterações na opacidade e interações de clique.
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Inicio drag");
        posicaoOriginal = rt.anchoredPosition; //Guarda a posição Original
        grupo.alpha = 0.3f;
        grupo.blocksRaycasts = false; //Faz com que o objeto não bloqueie interações com objetos por trás dele
        foiDropValido = false; // reseta
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Fim drag");
        grupo.alpha = 1f;
        grupo.blocksRaycasts = true;

        // Verifica se não foi solto em nenhum Drop
        if (!foiDropValido)
        {
            VoltarParaOrigem(); // volta para a posição original
        }
    }

    public void OnDrag(PointerEventData eventData)
    { //eventData.delta: Movimento do ponteiro desde o último frame

        //coloca a minha imagem na posição do mouse está indo
        rt.anchoredPosition += eventData.delta; // anchoredPosition para mover corretamente dentro do Canvas
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Apertou");
    }
    
    public void VoltarParaOrigem() //Faz o objeto voltar a posiçaõ original
    {
        rt.anchoredPosition = posicaoOriginal;
    }


}
