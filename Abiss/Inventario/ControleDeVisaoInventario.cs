using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControleDeVisaoInventario : MonoBehaviour
{
    [SerializeField] private TMP_Text _nomeTextoItem;
    [SerializeField] private TMP_Text _descricaoItem;
    public void OnSlotSelecionado(SlotDeItem slotselecionado)
    {
        if (slotselecionado._itemData == null)
        {
            _nomeTextoItem.ClearMesh();
            _descricaoItem.ClearMesh();
            return;
        }
        _nomeTextoItem.SetText(slotselecionado._itemData.Nome);
        _descricaoItem.SetText(slotselecionado._itemData.Descricao[0]);
    }


}
