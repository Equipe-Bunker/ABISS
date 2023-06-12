using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    
    public GameObject Prefab;
    [SerializeField] ScriptInventory invPlayer;
    [SerializeField] float tempoParadoTiro;
    [SerializeField] int municaoMax;
    [SerializeField] float tempoRecargaCadaBala;
    [SerializeField] float tempoRecarga;
    int municao;

    AudiosPequenos audiosPequenos;
    Player player;

    public AudioClip audioMira;
    public AudioSource audioSource;

    bool mira;
    int i = 0;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
        StartCoroutine(Recarregar());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Recarregar());
        }
        if (Input.GetMouseButton(1))
        {
            i ++;
            if (!audioSource.isPlaying && i == 1)
            {
                // Toca o AudioClip
                audioSource.clip = audioMira;
                audioSource.Play();

                player.AnimacaoMira();
            }
            if(Input.GetMouseButtonDown(0) && !GerenciarTempo.VerificarPause() && !player.GetParado())
            {
                Atirar();
            }
        }
        else
        {
            player.AnimacaoTiraMira();
            mira = false;
            i = 0;
        }
    }

    IEnumerator Recarregar()
    {

        //COLOQUE O SOM AQUI
        if (invPlayer.ProcurarQuantidade("Pregos") > 0)
        {
            audiosPequenos.SomRecarga();
        }
            
        //----

        yield return new WaitForSeconds(tempoRecarga);
        while (municao < municaoMax)
        {
            Debug.Log(municao);
            if (invPlayer.ProcurarQuantidade("Pregos") > 0)
            {
                
                municao++;
                invPlayer.RemoverItem(invPlayer.ProcurarItem("Pregos"), 1);
                yield return new WaitForSeconds(tempoRecargaCadaBala);
            }
            else
            {
                yield return null;
            }
        }
    }

    public int GetMunicao()
    {
        return municao;
    }

    public void Atirar(){
        if (municao > 0)
        {
            audiosPequenos.SomTiro();
            StartCoroutine(player.AnimacaoTiro(tempoParadoTiro));
            StartCoroutine(Atirar(0.135f));
            SalvarInformacoes.EscreverLinha("Deu tiro com a arma de pregos");
        }
        else
        {
            StartCoroutine(Recarregar());
            Debug.Log("Sem Pregos/Municao - Recarregando caso aja municao");
            SalvarInformacoes.EscreverLinha("Tentou dar tiro sem municao");
        }
    }

    IEnumerator Atirar(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        Instantiate(Prefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
        municao -= 1;
    }
}
