using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private string tagCorreta;  //Verificar se o item correto foi arrastado
    [SerializeField] private Animator personagemAnimator;
    [SerializeField] private Animator personagemAnimatorT;
    //SerializeField: Permite que o campo tagCorreta apareça no Inspector do Unity, mesmo sendo private.
    private void Start()
    {
        personagemAnimator.gameObject.SetActive(false);
        personagemAnimatorT.gameObject.SetActive(false);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) //verifica se existe elemento sendo arrastado
        {
            RectTransform dragged = eventData.pointerDrag.GetComponent<RectTransform>(); //Guarda o componente que foi arrastado

            if (!eventData.pointerDrag.CompareTag(tagCorreta))
            {
                GameManager.instance.SubtractScore(1); // Perde ponto
                // Volta para a posição original
                eventData.pointerDrag.GetComponent<DragAndDrop>().VoltarParaOrigem();
                if (personagemAnimatorT != null)
                {
                    personagemAnimatorT.gameObject.SetActive(true);
                    personagemAnimatorT.SetTrigger("Triste");
                    StartCoroutine(VoltarParaIdleDepois(2f));
                }
            }
            else
            {
                // Marca como drop válido
                eventData.pointerDrag.GetComponent<DragAndDrop>().foiDropValido = true;

                dragged.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;


                if (personagemAnimator != null)
                {
                    personagemAnimator.gameObject.SetActive(true); // Garante visibilidade
                    personagemAnimator.SetTrigger("Comemorar");
                    StartCoroutine(VoltarParaIdleDepois(2f));
                }
            }
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
    private IEnumerator VoltarParaIdleDepois(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        personagemAnimator.gameObject.SetActive(false);
        personagemAnimatorT.gameObject.SetActive(false);
    }
}
