using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    Player playerAbaixado;
    public GameObject abrirCanvas;
    PrecisaItemPuzzle pip;
    AudiosPequenos au;
    FadeControler fade;
    [SerializeField] bool precisaItem , portaMetal, portaMadeira, portaEletronica, portaLateralEletronica;
    [SerializeField] Transform destination;
    [SerializeField] float tempo;
    Animator anim;
    Escadas escadas;
    GameObject player;
    IEnumerator animacao;
    bool utilizavel, abriu;
    public bool soPodeAbaixado;
    int n = 0;
    public bool travada;
    public LiberaPuzzle puzzle;


    private void Start()
    {
        escadas = FindObjectOfType<Escadas>();
        playerAbaixado = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        au = FindObjectOfType<AudiosPequenos>();
        pip = FindObjectOfType<PrecisaItemPuzzle>();
        fade = FindObjectOfType<FadeControler>();
        anim = null;
        animacao = Fechando() ;
        if (GetComponent<Animator>())
        { 
            anim = GetComponent<Animator>(); 
        }

        if(precisaItem == true)
        {
            if (pip.retirouItem == true)
            {
                gameObject.GetComponent<PrecisaItemPuzzle>().enabled = false;
            }
        }
        

        
        //fade.anim.SetBool("ativa", true);
    }
    private void Update()
    {
        //VerificarPuzzleCompleto();
        if (gameObject.GetComponent<PrecisaItemPuzzle>() && !gameObject.GetComponent<PrecisaItemPuzzle>().retirouItem)
        {
            return;
        }
       // if (travada = false && Input.GetKeyDown(KeyCode.E) && utilizavel) 
       // {
       //     StartCoroutine(Abrindo());
       //     Animacoes();
       // }

        if(Input.GetKeyDown(KeyCode.E) && playerAbaixado.agachado == true && soPodeAbaixado == true && utilizavel)
        {
            StartCoroutine(Abrindo());
        }

        if (Input.GetKeyDown(KeyCode.E) && utilizavel)
        {
            //escadas.Fade();
            Animacoes();
            StartCoroutine(Abrindo());
        }  
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.gameObject;
            utilizavel = true;
            abrirCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = null;
            utilizavel = false;
            abrirCanvas.SetActive(false);
        }
    }

    IEnumerator Abrindo()
    {
        float tempoAbrido = tempo;
        if (portaMadeira && n==1)
        {
            au.PortaMadeira();
        }
        else if (portaEletronica)
        {
            //yield return new WaitForSeconds(0.5f);
            au.PortaEletronica();
        }
        else if (portaLateralEletronica)
        {
            au.PortaEletronica();
        }
        else if (portaMetal)
        {
            au.PortaEletronica();
            escadas.Fade();
        }

        if (abriu)
        {
            tempoAbrido /= 2;
        }

        //fade.anim.SetBool("ativa", true);
        if (player)
        {
            player.GetComponent<Player>().SetParado(true);
            player.GetComponent<Player>().playerRig.velocity = Vector2.zero;
        }
        if (destination.GetComponent<Porta>()) { destination.GetComponent<Porta>().SetAbriu(true); }
        yield return new WaitForSeconds(tempoAbrido);
        
        if (player) { 
            player.transform.position = destination.position;
            player.GetComponent<Player>().SetParado(false);
        }
        SetAbriu(true);
    }

    public void Animacoes()
    {


        if(anim != null && (portaEletronica || portaLateralEletronica || portaMetal))
        {
            abriu = false;
            anim.SetBool("Abrir", true);
            
            
            StartCoroutine(Fechando());
        }
        else if(anim != null)
        {
            n++;
            if (portaMadeira) 
            { 
                anim.SetBool("Aberta", true); 
            }
            anim.SetBool("Abrir", true);
        }
    }

    IEnumerator Fechando()
    {
        yield return new WaitForSeconds(tempo);
        if (GetComponent<Animator>())
        {
            anim.SetBool("Abrir", false);
        }
    }

    public bool GetAbriu()
    {
        return abriu;
    }
    
    public void SetAbriu(bool abriu)
    {
        this.abriu = abriu;
        if (abriu) { 
            Animacoes();
            if (gameObject.GetComponent<PrecisaItemPuzzle>()) { 
                gameObject.GetComponent<PrecisaItemPuzzle>().Aberto(true); 
                gameObject.GetComponent<PrecisaItemPuzzle>().enabled = false; }
        }
    }
    //public void VerificarPuzzleCompleto()
    //{
    //    if (puzzle.AtivaPuzzle)
    //    {
    //        DestravarPorta();
    //    }
    //}
    //private void DestravarPorta()
    //{
        
    //    travada= false;
    //}
    //private void DesativarPorta()
    //{
    //    // Desativa a interação com a porta quando ela estiver travada
    //    travada = true;
    //    // Adicione aqui o código para alterar a aparência visual da porta para indicar que está travada
    //}
}
