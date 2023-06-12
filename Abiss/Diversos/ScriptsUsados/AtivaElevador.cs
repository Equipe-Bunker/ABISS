using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class AtivaElevador : MonoBehaviour
{
    public Animator anim;
    public GameObject interagir;
    public TextMeshProUGUI textoInteragir;
    AudiosPequenos audiosPequenos;

    bool tocando, aberta;

    // Start is called before the first frame update
    void Start()
    {
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocando == true)
        {
            anim.SetBool("Abrir", true);
            SalvarInformacoes.EscreverLinha("Chamou o elevador da sala 5 (chefe)");

            StartCoroutine(EsperaElevador());
            
        }
        if (Input.GetKeyDown(KeyCode.E) && aberta == true && tocando == true)
        {
            SalvarInformacoes.EscreverLinha("Entrou no elevador da sala 5 (chefe)");
            SceneManager.LoadScene("Cutscene2");
        }
    }

    IEnumerator EsperaElevador()
    {
        yield return new WaitForSeconds(2f);
        audiosPequenos.SomElevador();
        textoInteragir.text = "Entrar";
        aberta = true;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo elevador da sala 5 (chefe)");
            interagir.SetActive(true);
            tocando = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            interagir.SetActive(false);
            tocando = false;
        }
    }
}
