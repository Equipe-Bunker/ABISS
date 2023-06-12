using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;


public class SalaChefe : MonoBehaviour
{
    public GameObject interagir, mensagem, elevador, estantes;
    public TextMeshProUGUI textMensagem;
    public string texto;
    public PlayableDirector playableDirector;
    AudiosPequenos audiosPequenos;
    bool tocando;
    Player player;

    bool abrido;

    // Start is called before the first frame update
    void Start()
    {
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tocando)
        {
            SalvarInformacoes.EscreverLinha("Ativou o quadro da sala 5 (chefe)");
            StartCoroutine(Ativa());
        }
    }

    public IEnumerator Ativa()
    {
        player.SetParado(true);
        interagir.SetActive(false);
        tocando = false;
        playableDirector.Play();
        elevador.SetActive(true);
        abrido = true;
        textMensagem.text = texto;
        audiosPequenos.BarulhoQuandro();
        StartCoroutine(Mensagem());
        yield return new WaitForSeconds(1.5F);
        player.SetParado(false);
    }

    public bool GetSave()
    {
        return abrido;
    }

    public void SetSave(bool s)
    {
        if (s)
        {
            abrido = true;
            elevador.SetActive(true);
            estantes.SetActive(false);
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
        if (!abrido && col.CompareTag("Player"))
        {
            SalvarInformacoes.EscreverLinha("Passou pelo quadro da sala 5 (cehefe)");
            interagir.SetActive(true);
            tocando = true;
            player = col.GetComponent<Player>();
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
