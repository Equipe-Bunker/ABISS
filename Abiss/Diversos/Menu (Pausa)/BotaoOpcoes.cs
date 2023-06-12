using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoOpcoes : MonoBehaviour
{
    [SerializeField] GameObject videoH, audioH, controleH, creditosH, opcoesH, fecharH;
    public void FecharHud()
    {
        videoH.SetActive(false);
        audioH.SetActive(false);
        controleH.SetActive(false);
        creditosH.SetActive(false);
        opcoesH.SetActive(false);
        fecharH.SetActive(false);
    }

    public void botaoFecharAbrir()
    {
        if (opcoesH.activeSelf)
        {
            FecharHud();
        }
        else
        {
            opcoesH.SetActive(true);
            fecharH.SetActive(true);
        }
    }
    
    public bool VerificarAberto()
    {
        if (opcoesH.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
