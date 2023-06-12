using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public GameObject hudInventario;
    public GameObject hudUpgrade;
    public GameObject hudInformacoes;
    //public GameObject barraVida;
    
    void Awake()
    {
        //hudInventario = GameObject.FindGameObjectWithTag("Inventario");
        //hudUpgrade = GameObject.FindGameObjectWithTag("hudUpgrade");
        //hudInformacoes = GameObject.Find("InformacoesHud");
        //barraVida = GameObject.Find("BarraVida");
        hudInformacoes.SetActive(false);
        hudInventario.SetActive(false);
        //barraVida.SetActive(false);
        //hudUpgrade.SetActive(false);
    }

    //Ativar e desativar informações dos itens no HUD
    Button i2 = null;
    public void EnableDisableInfo(Button i){
        if(hudInformacoes.activeSelf && i2 == i){
            hudInformacoes.SetActive(false);
        }else{
            hudInformacoes.SetActive(true);
            i2 = i;
        }
    }
}
