using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gerador : MonoBehaviour
{
    LiberaPuzzle liberaPuzzle;
    public Sprite novoSprite;
    public GameObject luzes;
    bool podeInteragir = false;
    public bool geradorLigado, ativaPainel;
    public GameObject interagir, painel;
    public AudioSource audioSource;
    PainelComSenha painelComSenha;
    int i = 0;
    //privados
    
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        liberaPuzzle = FindObjectOfType<LiberaPuzzle>();
        painelComSenha = FindObjectOfType<PainelComSenha>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        geradorLigado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (podeInteragir == true && Input.GetKeyDown(KeyCode.E) && i == 0)
        {
            Ligar();
            geradorLigado = true;
        }
        /*if (geradorLigado == true)
        {
            podeInteragir = false;
        }*/
    }
    public void Ligar()
    {
        //i++;
        liberaPuzzle.geradoresLigados++;
        luzes.SetActive(true);
        spriteRenderer.sprite = novoSprite;
        audioSource.Play();
        if(ativaPainel == true)
        {
            painel.GetComponent<BoxCollider2D>().enabled = true;
            painelComSenha.TrocarSprite();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = true;
            interagir.SetActive(true);
        }
        if (col.gameObject.name.Equals("Dardo(Clone)"))
        {
            
            Ligar();
            geradorLigado = true;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = false;
            interagir.SetActive(false);
        }
    }
}
