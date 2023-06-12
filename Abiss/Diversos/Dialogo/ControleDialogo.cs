using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControleDialogo : MonoBehaviour
{
    [Header("Components")]
    public GameObject janelaDialogo;
    public Image perfil; //Caso queira colocar o rosto dos personagens nas falas
    public TextMeshProUGUI textoFala;
    public TextMeshProUGUI nomeAtor;


    [Header("Settings")]
    public float velocidadeDigitacao, velociText;
    private string[] falas;
    private int index;
    float tempoPular;

    private bool mostrando;
    public bool cabou = false;
    Player parado;
    AudiosPequenos audiosPequenos;
    IEnumerator fala;

    public void Start()
    {
        parado = FindObjectOfType<Player>();
        fala = TipoDialogo();
    }

    public void Fala(/*Sprite p,*/ string[] txt, string nmAtor)
    {
        if (mostrando)
            return;

        janelaDialogo.SetActive(true);
        //perfil.sprite = p;
        falas = txt;
        nomeAtor.text = nmAtor;
        mostrando = true;
        parado.SetParado(true);
        StartCoroutine(TipoDialogo());
        if(mostrando == false)
        {
            janelaDialogo.SetActive(false);
        }
    }

    IEnumerator TipoDialogo() // Animação do dialogo sendo mostrado
    {
        foreach(char letra in falas[index].ToCharArray())
        {
            textoFala.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }
    }


    public void ProximaFala()
    {
        if (textoFala.text == falas[index] && tempoPular < Time.time)
        {
            //Ainda há textos
            if(index < falas.Length - 1)
            {
                index++;
                textoFala.text = "";
                
                StartCoroutine(TipoDialogo());

            }
            else //Lido quando acaba os textos
            {
                textoFala.text = "";
                index = 0;
                mostrando = false;
                parado.SetParado(false);
                cabou = true;
                janelaDialogo.SetActive(false);
                
            }
        }
        else if (textoFala.text != falas[index])
        {
            StopAllCoroutines();
            textoFala.text = falas[index];
            tempoPular = Time.time + 1f;
        }
    }

    public bool GetCabou()
    {
        return cabou;
    }

    public void SetCabou(bool cabo)
    {
        cabou = cabo;
    }
}
