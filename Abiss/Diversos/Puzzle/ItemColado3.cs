using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemColado3 : MonoBehaviour, IDropHandler
{
    [SerializeField] PuzzleLiquido puzzleLiquido;
    [SerializeField] Button botaoCima, botaoBaixo;
    bool dropou;

    public Sprite imagemLuz, imagemApagada;
    public Image imagem;
    
    private void Start()
    {
        //puzzleLiquido = FindObjectOfType<PuzzleLiquido>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log("Dropou Item");
            //puzzleLiquido.AtivaEnergia();
            HabilitarBotoes(true);
            imagem.sprite = imagemLuz;
        }
        
        
    }

    public void HabilitarBotoes(bool habilitar)
    {
        if (botaoCima != null)
        {
            botaoCima.interactable = habilitar;
        }

        if (botaoBaixo != null)
        {
            botaoBaixo.interactable = habilitar;
        }
    }

    public void ImagemApagada()
    {
        imagem.sprite = imagemApagada;
    }

}
