using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ColocaBateria2 : MonoBehaviour
{
    public GameObject canvasPergunta;
    public TextMeshProUGUI txtPergunta;
    public PuzzleBateria2 puzzleBateria;
    public AudioClip audioGerador;
    AudioSource audioSource;

    public ScriptInventory invPlayer;
    public GameObject interagir;
    public string nomeItem;
    
    bool instanciou = false;
    bool retirouBateria;
    bool estaTocando;
    
    bool bateria;
    
    public GameObject prefabBateria;


    int n;
    bool botaoConfirmar;

    public GameObject mensagem;
    public TextMeshProUGUI texto;

    CriarItens itens;

    public GameObject luz;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && estaTocando && invPlayer.ProcurarItem(nomeItem))
        {
            canvasPergunta.SetActive(true);
            txtPergunta.text = "Deseja depositar " + nomeItem + "?";
        }


        if (Input.GetKeyDown(KeyCode.E) && estaTocando && !invPlayer.ProcurarItem(nomeItem))
        {
            audioSource.Stop();
            StartCoroutine(SemBateria());

            if (Input.GetKeyDown(KeyCode.E) && retirouBateria == true)
            {
                canvasPergunta.SetActive(true);

                txtPergunta.text = "Deseja retirar " + nomeItem + "?";
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && estaTocando && invPlayer.ProcurarItem(nomeItem) && bateria == true)
        {
            Debug.Log("passou por essa condicao");
            audioSource.Stop();
            canvasPergunta.SetActive(true);

            txtPergunta.text = "Deseja retirar " + nomeItem + "?";

            /*if (Input.GetKeyDown(KeyCode.E) && retirouBateria == true)
            {
                
            }*/
        }
    }


    public void BotaoConfirmar()
    {
        if (botaoConfirmar == false)
        {
            AtivarComItem();
        }
        if (botaoConfirmar == true)
        {
            Instanciar();
            botaoConfirmar = false;
        }
    }
    public void Instanciar()
    {
        Debug.Log("instanciou");

        Instantiate(prefabBateria, transform.position, transform.rotation);
        instanciou = true;
        StartCoroutine(SemBateria());
    }

    public void AtivarComItem()
    {
        StartCoroutine(ComBateria());
        bateria = true;

        audioSource.clip = audioGerador;

        audioSource.Play();
    }

    IEnumerator ComBateria()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("A bateria foi colocada");

        texto.text = "A bateria foi colocada";


        bateria = true;

        StartCoroutine(Mensagem());

        if (bateria == true)
        {
            n++;
            if (n == 1)
            {
                puzzleBateria.ativo++;
                luz.SetActive(true);
            }

            botaoConfirmar = true;

            invPlayer.RemoverItem(invPlayer.ProcurarItem(nomeItem), 1);


            retirouBateria = true;

            if (invPlayer.ProcurarQuantidade(nomeItem) < 1)
            {
                Debug.Log("removeu bateria do inventario");
                invPlayer.RemoverItem(invPlayer.ProcurarItem(nomeItem));
            }


        }

    }

    IEnumerator SemBateria()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Precisa de bateria");
        bateria = false;



        if (instanciou == true)
        {
            n = 0;
            puzzleBateria.ativo--;
            texto.text = "Bateria Retirada";
            luz.SetActive(false);
            botaoConfirmar = false;
        }
        else
        {
            texto.text = "Bateria é necessária";
        }

        StartCoroutine(Mensagem());


    }

    IEnumerator Mensagem()
    {
        yield return new WaitForSeconds(0.1f);

        mensagem.SetActive(true);
        yield return new WaitForSeconds(2f);
        mensagem.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            estaTocando = true;
            interagir.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            interagir.SetActive(false);
            estaTocando = false;
        }
    }
}
