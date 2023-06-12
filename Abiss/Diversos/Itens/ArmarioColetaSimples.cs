using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ArmarioColetaSimples : MonoBehaviour
{
    public bool temTutorial, coletaSimples, desbloqueiaMapa;
    public GameObject interagir, tutorial, luz;
    bool podeInteragir = false;
    public GameObject prefabItem, mensagem;
    int umavez = 0;
    string sala;
    AudiosPequenos audiosPequenos;
    [SerializeField] MarcadorMapa mapa;

    public TextMeshProUGUI textoMensagem;
    public string mensagemtxt;
    // Start is called before the first frame update
    void Start()
    {
        if (!mapa)
        {
            mapa = FindObjectOfType<MarcadorMapa>();
        }
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(podeInteragir == true)
        //{
        //    interagir.SetActive(true);
        //}
        //else
        //{
        //    interagir.SetActive(false);
        //}

        Coleta();
    }

    public void Coleta()
    {
        if(desbloqueiaMapa && podeInteragir && Input.GetKeyUp(KeyCode.E))
        {
            mensagem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Mapa Coletado";
            StartCoroutine(Mensagem());
            audiosPequenos.ColetaItem();
            mapa.DesbloqueiaMapa();
            luz.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
        }



        if (!desbloqueiaMapa && podeInteragir && Input.GetKeyUp(KeyCode.E))
        {
            umavez++;
            if(umavez == 1)
            {
                DropaItem();
            }
            
        }
    }


    public void DropaItem()
    {

        if(coletaSimples == true)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            luz.SetActive(false);
        }
        Instantiate(prefabItem, transform.position, transform.rotation);
        audiosPequenos.ColetaItem();
        SalvarInformacoes.EscreverLinha("Item Coletado: {" + prefabItem.name + "} na " + sala ); if (umavez == 1)
        {
            textoMensagem.text = mensagemtxt;
        }
        StartCoroutine(Mensagem());
        
    }

    IEnumerator Mensagem()
    {
        if(temTutorial == true)
        {
            tutorial.SetActive(true);
        }
        
        yield return new WaitForSeconds(0.1f);

        mensagem.SetActive(true);
        yield return new WaitForSeconds(3f);
        mensagem.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = true;
            interagir.SetActive(true);
        }
        if (col.GetComponent<EncostouTeste>())
        {
            sala = col.GetComponent<EncostouTeste>().gameObject.name;
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
