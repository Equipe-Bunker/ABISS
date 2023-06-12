using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSegurar : MonoBehaviour
{
    [SerializeField] GameObject hudLuz, hudArma;
    [SerializeField] TMP_Dropdown luz, arma;
    [SerializeField] ScriptInventory invPlayer;
    List<TMP_Dropdown.OptionData> listLuz = new List<TMP_Dropdown.OptionData>();
    List<TMP_Dropdown.OptionData> listArma = new List<TMP_Dropdown.OptionData>();
    int selLuz, selArma;

    public void AtualizarSlots()
    {
        hudLuz.SetActive(false);
        hudArma.SetActive(false);
        AdicionarItemLuz();
        AdicionarItemArma();
    }

    public Item LuzSelecionada()
    {
        if (invPlayer.ProcurarTipo(Item.tipo.Iluminacoes).Length > 0)
        {
            return invPlayer.ProcurarTipo(Item.tipo.Iluminacoes)[selLuz];
        }
        else
        {
            return null;
        }
    }

    public Item ArmaSelecionada()
    {
        if (invPlayer.ProcurarTipo(Item.tipo.Armas).Length > 0)
        {
            return invPlayer.ProcurarTipo(Item.tipo.Armas)[selArma];
        }
        else
        {
            return null;
        }
    }

    public void DropdownSelecionado()
    {
        selLuz = luz.value;
        selArma = arma.value;
    }

    void AdicionarItemLuz()
    {
        luz.ClearOptions();
        listLuz.Clear();
        for (int a = 0; a < invPlayer.ProcurarTipo(Item.tipo.Iluminacoes).Length; a++)
        {
            hudLuz.SetActive(true);
            TMP_Dropdown.OptionData newItem = new TMP_Dropdown.OptionData(invPlayer.ProcurarTipo(Item.tipo.Iluminacoes)[a].nome);
            listLuz.Add(newItem);
        }
        luz.AddOptions(listLuz);
        luz.value = selLuz;
    }

    void AdicionarItemArma()
    {
        if (invPlayer.ProcurarTipo(Item.tipo.Armas).Length > 0){
            hudArma.SetActive(true);
            listArma.Clear();
            for (int a = 0; a < invPlayer.ProcurarTipo(Item.tipo.Armas).Length; a++)
            {
                TMP_Dropdown.OptionData newItem = new TMP_Dropdown.OptionData(invPlayer.ProcurarTipo(Item.tipo.Armas)[a].nome);
                listArma.Add(newItem);
            }
            arma.ClearOptions();
            arma.AddOptions(listArma);
            arma.value = selArma;
        }
    }


}