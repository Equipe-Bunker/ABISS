using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotDeItem : MonoBehaviour , ISelectHandler
{
    //[SerializeField] private DadoItem _itemData;
    public DadoItem _itemData;

    private ControleDeVisaoInventario _controleDevisao;
    public void OnSelect(BaseEventData eventData)
    {
        _controleDevisao.OnSlotSelecionado(this);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _controleDevisao = FindObjectOfType<ControleDeVisaoInventario>();
        if (_itemData == null) return;

        var surgirSprite = Instantiate<Image>(_itemData.Sprite, transform.position, Quaternion.identity, transform);
    }

 
}
