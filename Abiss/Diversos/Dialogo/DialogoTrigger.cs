using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite perfil;
    [TextArea(3, 5)]
    public string[] falaTxt;
    public string nomeAtor;


    public string txtGUI; //texto que será mostrado ao se aproximar do NPC
                          //Exemplos: Investigar, interagir, falar etc


    public LayerMask playerLayer;
    public float radio;

    
    private ControleDialogo dc, pf, rf;
    public bool noAlcance;
    bool noDialogo = false;
    bool saiuDialogo;

    

    private void Start()
    {
        dc = FindObjectOfType<ControleDialogo>();
        pf = FindObjectOfType<ControleDialogo>();
        
    }

    private void FixedUpdate()
    {
        Interagir();
    }

    private void Update()
    {
        noDialogo = false;
        if (/*Input.GetKeyUp(KeyCode.E) && */noAlcance == true && dc.cabou == false)
        {
            dc.Fala(/*perfil,*/ falaTxt, nomeAtor);
            noDialogo = true;
        }

        if (Input.GetKeyUp(KeyCode.E) && noDialogo == true)
        {
            dc.ProximaFala();

            if(dc.cabou == true)
            dc.janelaDialogo.SetActive(false);
            
        }


    }

    public void Interagir()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radio, playerLayer);

        if (hit != null)
        { 
            noAlcance = true;
        }
        else
        {
            noAlcance = false;
            
        }

    }
    /*private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (noAlcance == false)
            {
                pf.janelaDialogo.SetActive(false);
            }
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radio);
    }


    void OnGUI() 
    {
        if (noAlcance == true)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 30;
            GUI.Label(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 200, 40), txtGUI);

        }


    }


}
