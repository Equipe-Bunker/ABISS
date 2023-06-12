using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class ChamarDialogo1 : MonoBehaviour
{
    
    //public string nomeItem;
    public ScriptInventory invPlayer;
    Player player;
    int n;
    public GameObject dialogo;

    AudioFase audioFase;
    
    //bool ativo;
    public UnityEvent evento;
    bool podeInteragir;
    
    

    
    FadeControler fade;

    void Start()
    {
        audioFase = FindObjectOfType<AudioFase>();
        fade = GetComponent<FadeControler>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }

    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //ativo = true;
            evento.Invoke();
            player.SetParado(true);
            podeInteragir = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = false;
            //ativo = false;
        }  
    }

    public void FimDialogo()
    {
        player.SetParado(false);
    }

    public void DesativaDialogo()
    {
        dialogo.SetActive(false);

    }

    public void FlipPlayer()
    {
        player.Flip();
    }

}
