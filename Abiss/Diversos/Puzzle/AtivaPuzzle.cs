using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtivaPuzzle : MonoBehaviour
{
    
    public GameObject puzzle;
    public GameObject interagirPuzzle;
    bool podeAtivar;

    public bool precisaItem;
    Player player;
    public string nomeItem;
    public GameObject mensagem;
    public TextMeshProUGUI texto;
    bool estaTocando;
    public bool retirouItem;
    bool item;
    int n;
    public string textoColetou;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(precisaItem == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && podeAtivar && player.inventario.inventario.Exists(x => x.item.nome.Equals(nomeItem)))
            {

                StartCoroutine(ComItem());
                item = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && podeAtivar && !player.inventario.inventario.Exists(x => x.item.nome.Equals(nomeItem)))
            {

                StartCoroutine(SemItem());
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Nao tem item");
                }
            }
        }

        if(precisaItem == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && podeAtivar == true)
            {
                puzzle.SetActive(true);
                interagirPuzzle.SetActive(false);
            }
        }

        
    }


    IEnumerator ComItem()
    {
        yield return new WaitForSeconds(0.1f);
        

        texto.text = textoColetou;

        

        StartCoroutine(Mensagem());

        if (item == true)
        {

            //player.inventario.inventario[player.inventario.inventario.FindIndex(x => x.item.nome == "Bateria")].quantidade -= 1;

            // Remover item do inventario usando a posicao dele no array
            n = player.inventario.inventario.FindIndex(x => x.item.nome == nomeItem);
            player.inventario.inventario.RemoveAt(n);

            retirouItem = true;
            precisaItem = false;

        }

    }


    IEnumerator SemItem()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Precisa de Item");
        item = false;



        if (item == false)
        {
            texto.text = nomeItem + " é necessario";
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





    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interagirPuzzle.SetActive(true);
            podeAtivar = true;
        }
        

    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        podeAtivar = false;
        if (collision.gameObject.CompareTag("Player"))
        {
            interagirPuzzle.SetActive(false);
            
        }
    }


    public void VoltarPuzzle()
    {
        puzzle.SetActive(false);
    }


}
