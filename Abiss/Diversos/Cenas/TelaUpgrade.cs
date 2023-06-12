using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaUpgrade : MonoBehaviour
{
    Canvas canvas;
    GameObject hudInventario;
    GameObject hudUpgrade;
    GameObject hudInformacoes;
    Player player;
    bool hudActive;
    bool estaNaMesa;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        hudUpgrade = canvas.hudUpgrade;
        hudInventario = canvas.hudInventario;
        hudInformacoes = canvas.hudInformacoes;
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            estaNaMesa = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            if(hudUpgrade.activeSelf || hudInventario.activeSelf){
                hudUpgrade.GetComponent<Upgrade>().textIn();
                player.SetParado(false);
                hudInformacoes.SetActive(false);
                hudInventario.SetActive(false);
                hudUpgrade.SetActive(false);
            }
            estaNaMesa = false;
            hudActive = false;
        }
    }
    void Update(){
        if(!hudInventario.activeSelf && !hudUpgrade.activeSelf){
            hudActive = false;
        }
        if(estaNaMesa && Input.GetKeyDown(KeyCode.E) && !hudActive){
            hudInventario.transform.GetChild(1).GetComponent<GerenciarInventario>().AtualizarInv();
            player.SetParado(true);
            hudActive = true;
            hudInventario.SetActive(true);
            hudInformacoes.SetActive(false);
            hudUpgrade.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.E) && hudActive){
            hudUpgrade.GetComponent<Upgrade>().textIn();
            player.SetParado(false);
            hudActive = false;
            hudInformacoes.SetActive(false);
            hudInventario.SetActive(false);
            hudUpgrade.SetActive(false);
        }
    }
}
