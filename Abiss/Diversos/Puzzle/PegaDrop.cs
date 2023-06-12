using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PegaDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{ 

    RectTransform rt;
    Image imagem;
    CanvasGroup grupo;
    ItemColado itemColado;
    ItemColado2 itemColado2;
    ItemColado3 itemColado3;
    private Vector2 posicaoInicial;

    
    private void Awake()
    {
        itemColado = FindObjectOfType<ItemColado>();
        itemColado2 = FindObjectOfType<ItemColado2>();
        itemColado3 = FindObjectOfType<ItemColado3>();
        rt = GetComponent<RectTransform>();
        grupo = GetComponent<CanvasGroup>();

        //posicaoInicial = rt.anchoredPosition;
        itemColado.HabilitarBotoes(false);
        itemColado2.HabilitarBotoes(false);
        itemColado3.HabilitarBotoes(false);

        itemColado.ImagemApagada();
        itemColado2.ImagemApagada();
        itemColado3.ImagemApagada();
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Começou a arrastar");
        grupo.alpha = 0.3f;
        grupo.blocksRaycasts = false; // Habilitando a colisao com o objeto que sera dropado

    }

    public void OnDrag(PointerEventData eventData)
    {
        // seta a posição do objeto para a posição do mouse
        Debug.Log("Arrastou");
        rt.anchoredPosition += eventData.delta;
        itemColado.HabilitarBotoes(false);
        itemColado2.HabilitarBotoes(false);
        itemColado3.HabilitarBotoes(false);

        itemColado.ImagemApagada();
        itemColado2.ImagemApagada();
        itemColado3.ImagemApagada();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Terminou arrastar");
        grupo.alpha = 1f;
        grupo.blocksRaycasts = true; //Desabilitando a colisao com o objeto que sera dropado


        
        //rt = GetComponent<RectTransform>();
        // Restaurar a posição inicial, pois o objeto não foi depositado corretamente
        //rt.anchoredPosition = posicaoInicial;



    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicou");
    }


    public void MetodoDoEvento()
    {
        
        
        Debug.Log("Evento Ativo");
        rt.anchoredPosition = posicaoInicial;

    }


}
