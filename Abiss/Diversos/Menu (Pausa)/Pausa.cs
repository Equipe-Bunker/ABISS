using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] BotaoOpcoes opcoes;
    public void AbrirMenuPausa()
    {
        menu.SetActive(true);
        opcoes.FecharHud();
    }

    public void FecharMenuPausa()
    {
        if (opcoes.VerificarAberto())
        {
            opcoes.FecharHud();
        }
        else
        {
            menu.SetActive(false);
        }
    }

    public bool VerificarAberto()
    {
        if (menu.activeSelf)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}
