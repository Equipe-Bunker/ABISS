using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelComSenha : MonoBehaviour
{


    public bool podeInteragir = false, painelAtivo;
    [SerializeField] GameObject interagirPainel;
    //[SerializeField] ScriptInventory invPlayer;
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    public GameObject painel, colisorPassarelaAntigo;
    GerenciaPuzzle gp;
    CodePanel cp;
    int umavez = 0;
    //public GameObject marco;
    //AudiosPequenos audiosPequenos;

    // Start is called before the first frame update
    void Start()
    {
        //audiosPequenos = FindObjectOfType<AudiosPequenos>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cp = FindObjectOfType<CodePanel>();
        gp = FindObjectOfType<GerenciaPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        AtivarPainel();

    }

    /*public void DropaItem()
    {
        //Instantiate(prefabItem, transform.position, transform.rotation);
        //Destroy(marco);
        Debug.Log("Ativou Painel");
        StartCoroutine(Mensagem());

    }*/

    public void BotaoVoltar()
    {
        painel.SetActive(false);
    }

    public void DesativaColisor()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        colisorPassarelaAntigo.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void TrocarSprite()
    {
        spriteRenderer.sprite = sprite;
    }

    void AtivarPainel()
    {
        if (podeInteragir == true && Input.GetKeyUp(KeyCode.E))
        {
            interagirPainel.SetActive(false);
            painel.SetActive(true);
            painelAtivo = true;
            Debug.Log("Ativou Painel");
            SalvarInformacoes.EscreverLinha("Abriu a hud da senha painel");

            
        }
        


    }
    /*public void AtivaMensagem()
    {
        
        StartCoroutine(Mensagem());
    }*/

    /*IEnumerator Mensagem()
    {
        yield return new WaitForSeconds(0.1f);

        mensagem.SetActive(true);
        yield return new WaitForSeconds(3f);
        mensagem.SetActive(false);
        gp.FechaArmario();
        
        //yield return new WaitForSeconds(1f);
        

    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo armario com senha da sala 8");
            podeInteragir = true;
            if (podeInteragir)
            {
                interagirPainel.SetActive(true);
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {

            podeInteragir = false;
            interagirPainel.SetActive(false);
            painel.SetActive(false);
            
        }
    }
}
