using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public GameObject sinal;

    public Sprite perfil;
    
    [TextArea(3, 5)]
    public string[] falaTxt;
    public string nomeAtor;

    
    
    public string txtGUI; //texto que será mostrado ao se aproximar do NPC
                          //Exemplos: Investigar, interagir, falar etc

    
    private ControleDialogo dc, pf, rf;
    public bool noAlcance;
    bool noDialogo = false;
    bool saiuDialogo;

    

    private void Start()
    {
        dc = FindObjectOfType<ControleDialogo>();
        pf = FindObjectOfType<ControleDialogo>();    
    }

    private void Update()
    {
        noDialogo = false;
        //if(noAlcance == true)
        //{
        //    sinal.SetActive(true);
        //}
        //else  sinal.SetActive(false);
        
        if (Input.GetKeyUp(KeyCode.E) && noAlcance)
        {

            dc.Fala(/*perfil,*/ falaTxt, nomeAtor);
            noDialogo = true;
        }

        if (Input.GetKeyUp(KeyCode.E) && noDialogo == true)
        {
            dc.ProximaFala();
            
        }


    }

   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //interagir.SetActive(true);
            noAlcance = true;
            sinal.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //interagir.SetActive(false);
            noAlcance = false;
            sinal.SetActive(false);
        }
    }


}
