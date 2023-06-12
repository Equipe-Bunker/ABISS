using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AtivaCanvasDoc : MonoBehaviour
{
    
    AudiosPequenos audiosPequenos;
    public bool temTutorial, temLuz;
    public GameObject tutorial;
    public GameObject luzMarcador;
    AtivaDocumento ad;
    public GameObject interagir, mensagem, imagemDocumento;
    public TextMeshProUGUI textoMensagem, textoDocumento;
    bool tocando;
    public string mensagemText;
    [TextArea(10, 10)]
    public string texto;
    Canvas documento;
    int n = 0;

    public int numeroDocumento;
    
    // Start is called before the first frame update
    void Start()
    {
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
        ad = FindObjectOfType<AtivaDocumento>();
    }

    // Update is called once per frame
    void Update()
    {
        AtivaCanvas();
        
    
    }

    

    public void AtivaCanvas()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocando == true)
        {
            SalvarInformacoes.EscreverLinha("Abriu o documento da sala 9");

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
            if(temLuz == true)
            {
                luzMarcador.SetActive(false);
            }

            imagemDocumento.SetActive(true);
            textoDocumento.text = texto;
            audiosPequenos.ColetaDocumento();
            n++;
            switch (numeroDocumento)
            {
                case 1:
                    ad.ativaDoc1();
                    break;
                case 2:
                    ad.ativaDoc2();
                    break;
                case 3:
                    ad.ativaDoc3();
                    break;
                case 4:
                    ad.ativaDoc4();
                    break;
                case 5:
                    ad.ativaDoc5();
                    break;
                case 6:
                    ad.ativaDoc6();
                    break;
                case 7:
                    ad.ativaDoc7();
                    break;
                case 8:
                    ad.ativaDoc8();
                    break;
                case 9:
                    ad.ativaDoc9();
                    break;
                case 10:
                    ad.ativaDoc10();
                    break;
            }
        }
        
        
    }

    public void DesativaCanvas()
    {
        imagemDocumento.SetActive(false);
        textoMensagem.text = mensagemText;
        if (n == 1)
        {
            StartCoroutine(Mensagem());
        }
        


    }

    public IEnumerator Mensagem()
    {
        yield return new WaitForSeconds(0.1f); 
        mensagem.SetActive(true);

        yield return new WaitForSeconds(3f);
        mensagem.SetActive(false);
        if (temTutorial == true)
        {
            tutorial.SetActive(true);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            interagir.SetActive(true);
            SalvarInformacoes.EscreverLinha("Passou pelo Documento da sala 9");
            
            tocando = true;
        }
    }
    /*private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo Documento da sala 9");
            
            tocando = true;
        }
    }*/

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            interagir.SetActive(false);
            tocando = false;
            

        }

        

    }

}
