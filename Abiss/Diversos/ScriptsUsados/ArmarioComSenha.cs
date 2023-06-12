using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmarioComSenha : MonoBehaviour
{


    public bool podeInteragir = false, painelAtivo;
    [SerializeField] GameObject interagirArmario;
    [SerializeField] ScriptInventory invPlayer;
    public GameObject mensagem;
    public GameObject painel, prefabItem;
    GerenciaPuzzle gp;
    CodePanel cp;
    int umavez = 0;
    public GameObject marco;


    // Start is called before the first frame update
    void Start()
    {
        cp = FindObjectOfType<CodePanel>();
        gp = FindObjectOfType<GerenciaPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        AtivarPainel();
        /*if (podeInteragir == true && invPlayer.ProcurarItem("Chave Do Escritorio"))
        {
            Destroy(marco);
            umavez++;
            if (umavez == 1)
            {
                Debug.Log("Ta com a chave");
                StartCoroutine(Mensagem());
            }

        }*/

    }

    public void DropaItem()
    {
        Instantiate(prefabItem, transform.position, transform.rotation);
        Destroy(marco);
        Debug.Log("Ta com a chave");
        StartCoroutine(Mensagem());

    }

    public void BotaoVoltar()
    {
        painel.SetActive(false);
    }


    void AtivarPainel()
    {
        if (podeInteragir == true && Input.GetKeyUp(KeyCode.E))
        {
            interagirArmario.SetActive(false);
            painel.SetActive(true);
            painelAtivo = true;
            Debug.Log("Coloque a senha + teste");
            SalvarInformacoes.EscreverLinha("Abriu a hud da senha do armario na sala 8");


        }
        


    }
    /*public void AtivaMensagem()
    {
        
        StartCoroutine(Mensagem());
    }*/

    IEnumerator Mensagem()
    {
        yield return new WaitForSeconds(0.1f);

        mensagem.SetActive(true);
        yield return new WaitForSeconds(3f);
        mensagem.SetActive(false);
        gp.FechaArmario();
        
        //yield return new WaitForSeconds(1f);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo armario com senha da sala 8");
            podeInteragir = true;
            if (podeInteragir)
            {
                interagirArmario.SetActive(true);
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {

            podeInteragir = false;
            interagirArmario.SetActive(false);
            painel.SetActive(false);
            
        }
    }
}
