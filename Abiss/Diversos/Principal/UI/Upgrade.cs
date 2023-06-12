using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{   
    Canvas canvas;
    Player player;
    Text textArm;
    Text textLan;
    
    bool atualizado;
    void Awake(){
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        textArm = GameObject.Find("TextArma").GetComponent<Text>();
        textLan = GameObject.Find("TextLan").GetComponent<Text>();
        textIn();
    }

    
    public void textIn(){
        if(player.inventario.inventario.Exists(x => x.item.nome.Contains("Arma"))){
            if(player.inventario.inventario.Find(x => x.item.nome.Equals("Arma")).item.level  ==  1){
                textArm.text = "Arma LVL. 1\n\nProximo Nivel:\nDano 2 -----> 3\n\n\nPrecisa de 5 Pregos para o proximo nivel";
            }else if(player.inventario.inventario.Find(x => x.item.nome.Equals("Arma")).item.level  ==  2){
                textArm.text = "Arma LVL. 2\n\nProximo Nivel:\nDano 3 -----> 4\n\n\nPrecisa de 10 Pregos para o proximo nivel";
            }else{
                textArm.text = "\n\n\nArma LVL. 3(MAX)";
            }
        }
        if(player.inventario.inventario.Exists(x => x.item.nome.Contains("Lanterna"))){
            if(player.inventario.inventario.Find(x => x.item.nome.Equals("Lanterna")).item.level  ==  1){
                textLan.text = "Lanterna LVL. 2\n\nProximo Nivel:\nLumens x -----> y\n\n\nPrecisa de 5 coisas para o proximo nivel";
            }else if(player.inventario.inventario.Find(x => x.item.nome.Equals("Lanterna")).item.level  ==  2){
                textLan.text = "Lanterna LVL. 2\n\nProximo Nivel:\nLumens y -----> z\n\n\nPrecisa de 10 coisas para o proximo nivel";
            }else{
                textLan.text = "\n\n\nLanterna LVL. 3";
            }
        }
    }

    public void UpArma(){
        if(player.inventario.inventario.Find(x => x.item.nome.Equals("Arma")).item.level  ==  1){
            if(player.inventario.inventario.Exists(x => x.item.name.Equals("Pregos"))){
                if(player.inventario.inventario.Find(x => x.item.name.Equals("Pregos")).quantidade >= 5){
                    player.inventario.inventario.Find(x => x.item.name.Equals("Pregos")).quantidade -= 5;
                    player.inventario.inventario.Find(x => x.item.nome.Equals("Arma")).item.level = 2;
                    canvas.hudInventario.transform.GetChild(1).GetComponent<GerenciarInventario>().AtualizarInv();
                    textIn();
                }else{
                    StartCoroutine(insulficiente("Arma LVL. 2"));
                }
            }else{
                Debug.Log("Sem Pregos");
            }
        }else if(player.inventario.inventario.Find(x => x.item.nome.Equals("Arma")).item.level  ==  2){
            if(player.inventario.inventario.Find(x => x.item.name.Equals("Pregos")).quantidade >= 10){
                player.inventario.inventario.Find(x => x.item.name.Equals("Pregos")).quantidade -= 10;
                player.inventario.inventario.Find(x => x.item.nome.Equals("Arma")).item.level = 3;
                canvas.hudInventario.transform.GetChild(1).GetComponent<GerenciarInventario>().AtualizarInv();
                textIn();
            }else{
                StartCoroutine(insulficiente("Arma LVL. 3"));
            }
        }
    }

    public void UpLanterna(){
        if(player.inventario.inventario.Find(x => x.item.nome.Equals("Lanterna")).item.level  ==  1){
            if(player.inventario.inventario.Exists(x => x.item.name.Equals("Coisas"))){
                if(player.inventario.inventario.Find(x => x.item.name.Equals("Coisas")).quantidade >= 5){
                    player.inventario.inventario.Find(x => x.item.name.Equals("Coisas")).quantidade -= 5;
                    player.inventario.inventario.Find(x => x.item.nome.Equals("Lanterna")).item.level = 2;
                    canvas.hudInventario.transform.GetChild(0).GetComponent<GerenciarInventario>().AtualizarInv();
                    textIn();
                }else{
                    StartCoroutine(insulficiente("Lanterna LVL. 2"));
                }
            }
        }else if(player.inventario.inventario.Find(x => x.item.nome.Equals("Lanterna")).item.level  ==  2){
            if(player.inventario.inventario.Find(x => x.item.name.Equals("Coisas")).quantidade >= 10){
                player.inventario.inventario.Find(x => x.item.name.Equals("Coisas")).quantidade -= 10;
                player.inventario.inventario.Find(x => x.item.nome.Equals("Lanterna")).item.level = 3;
                canvas.hudInventario.transform.GetChild(0).GetComponent<GerenciarInventario>().AtualizarInv();
                textIn();
            }else{
                StartCoroutine(insulficiente("Lanterna LVL. 3"));
            }
        }
    }

    IEnumerator insulficiente(string text){
        if(text == "Arma LVL. 2"){
            textArm.text = "Arma LVL. 1\n\nProximo Nivel:\nDano 2 -----> 3\n\nFaltam: "+ (5 - player.inventario.inventario.Find(x => x.item.name.Equals("Pregos")).quantidade) + " Pregos\nPrecisa de 5 Pregos para o proximo nivel";
            yield return new WaitForSeconds(3);
            textIn();
        }else if(text == "Arma LVL. 3"){
            textArm.text = "Arma LVL. 2\n\nProximo Nivel:\nDano 3 -----> 4\n\nFaltam: " + (10 - player.inventario.inventario.Find(x => x.item.name.Equals("Pregos")).quantidade) + " Pregos\nPrecisa de 10 Pregos para o proximo nivel";
            yield return new WaitForSeconds(3);
            textIn();
        }else if(text == "Lanterna LVL. 2"){
            textLan.text = "Lanterna LVL. 1\n\nProximo Nivel:\nLumens x -----> y\n\nFaltam: " + (5 - player.inventario.inventario.Find(x => x.item.name.Equals("Coisas")).quantidade) + " Coisas\nPrecisa de 5 coisas para o proximo nivel";
            yield return new WaitForSeconds(3);
            textIn();
        }else if(text == "Lanterna LVL. 3"){
            textLan.text = "Lanterna LVL. 2\n\nProximo Nivel:\nLumens y -----> z\n\nFaltam: " + (10 - player.inventario.inventario.Find(x => x.item.name.Equals("Coisas")).quantidade) + " Coisas\nPrecisa de 10 coisas para o proximo nivel";
            yield return new WaitForSeconds(3);
            textIn();
        }else{
            Debug.Log("Script 'Upgrade' Erro");
            yield return null;
        }
    }
}
