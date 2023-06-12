using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrecisaItemPuzzle : MonoBehaviour
{
    [SerializeField] ScriptInventory invPlayer;
    Player player;
    public string nomeItem;
    public GameObject mensagem;
    public TextMeshProUGUI texto;
    bool estaTocando;
    public bool retirouItem;
    bool item;
    int n;
    Porta porta;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        porta = GameObject.FindObjectOfType<Porta>();

        if (porta.GetAbriu())
        {
            gameObject.GetComponent<Porta>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && estaTocando && invPlayer.ProcurarItem(nomeItem))
        {
            SalvarInformacoes.EscreverLinha("Abriu a porta da sala 5 (Chefe)");
            StartCoroutine(ComItem());
            item = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && estaTocando && !invPlayer.ProcurarItem(nomeItem))
        {
            SalvarInformacoes.EscreverLinha("Tentou abrir a porta da sala 5 (Chefe) sem a chave");
            StartCoroutine(SemItem());
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Nao tem item");
            }
        }
    }

    IEnumerator ComItem()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Porta Destrancada");

        texto.text = "A porta foi destrancada";

        gameObject.GetComponent<Porta>().enabled = true;

        StartCoroutine(Mensagem());

        if (item == true)
        {

            //player.inventario.inventario[player.inventario.inventario.FindIndex(x => x.item.nome == "Bateria")].quantidade -= 1;

            // Remover item do inventario usando a posicao dele no array
            //n = player.inventario.inventario.FindIndex(x => x.item.nome == nomeItem);
            //player.inventario.inventario.RemoveAt(n);

            invPlayer.RemoverItem(invPlayer.ProcurarItem(nomeItem));
            


            retirouItem = true;


        }

    }

    IEnumerator SemItem()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Precisa de Item");
        item = false;
        


        if (item == false)
        {
            texto.text = nomeItem + " é necessaria";
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

    public void Aberto(bool abre)
    {
        if (abre)
        {
            retirouItem = true;
            item = true;
        }
        else 
        {
            retirouItem = false;
            item = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            estaTocando = true;

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            estaTocando = false;
        }
    }

    
}
