using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AtivaCanvasDoc1 : MonoBehaviour
{
    AtivaDocumento ad;
    public GameObject interagir, mensagem, imagemDocumento;
    public TextMeshProUGUI textoMensagem, textoDocumento;
    bool tocando;
    public string mensagemText;
    [TextArea(10, 10)]
    public string texto;
    Canvas documento;
    int n = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ad = FindObjectOfType<AtivaDocumento>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (tocando == true)
        {
            interagir.SetActive(true);
            AtivaCanvas();
        }
        else
        {
            interagir.SetActive(false);
        }

    }

    

    public void AtivaCanvas()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocando == true)
        {
            SalvarInformacoes.EscreverLinha("Ativou o documento do computador da sala 5 (chefe)");
            imagemDocumento.SetActive(true);
            textoDocumento.text = texto;
            ad.ativaDoc2();
            n++;
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

    IEnumerator Mensagem()
    {
        yield return new WaitForSeconds(0.1f); 
        mensagem.SetActive(true);

        yield return new WaitForSeconds(3f);
        mensagem.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo computador da sala 5 (chefe)");
            
            tocando = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            tocando = false;
        }
    }

}
