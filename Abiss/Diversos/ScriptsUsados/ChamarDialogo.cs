using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class ChamarDialogo : MonoBehaviour
{
    //public string nomeItem;
    public ScriptInventory invPlayer;
    Player player;
    int n;
    public GameObject dialogo, dialogoRepeticao;

    public GameObject dialogoSocorros, dialogoSocorros2;
    AudioFase audioFase;
    bool podeEntregar;
    //bool ativo;
    public UnityEvent evento;
    bool podeInteragir;
    public GameObject dialogoflashback, dialogoAposCena, portaRefeitorio;
    

    public PlayableDirector CenaFlashBack, cenainjecao;


    FadeControler fade;

    void Start()
    {
        audioFase = FindObjectOfType<AudioFase>();
        fade = GetComponent<FadeControler>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (podeInteragir== true && invPlayer.ProcurarItem("Kit SOS"))
        {

            //CanvasDialogoManager.SetActive(false);
            //CanvasOpcaoManager.SetActive(true);
            if (podeEntregar == true)
            {
                dialogo.SetActive(false);
                dialogoRepeticao.SetActive(false);
                dialogoSocorros.SetActive(true);
            }
            

        }
    }

    public void PortaRefeitorio()
    {
        portaRefeitorio.GetComponent<BoxCollider2D>().enabled = true;
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //ativo = true;
            evento.Invoke();
            player.SetParado(true);
            podeInteragir = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = false;
            //ativo = false;
        }  
    }

    public void FimDialogo()
    {
        player.SetParado(false);
    }

    public void AtivaInjeção()
    {
        dialogo.SetActive(false);
        dialogoRepeticao.SetActive(false);
        dialogoSocorros.SetActive(false);
        dialogoSocorros2.SetActive(true);
    }



    public void DesativaDialogo()
    {
        dialogo.SetActive(false);

        dialogoRepeticao.SetActive(true);
        //podeInteragir = true;

        
    }

    public void PodeEntregar()
    {
        podeEntregar = true;
    }


    public void EntregaKit()
    {
        invPlayer.RemoverItem(invPlayer.ProcurarItem("Kit SOS"));
        //n = player.inventario.inventario.FindIndex(x => x.item.nome == "Kit SOS");
        //player.inventario.inventario.RemoveAt(n);
    }
    public void DialogoFlashBack()
    {
        
        dialogoSocorros2.SetActive(false);
        //StartCoroutine(Fade());
        dialogoflashback.SetActive(true);
        audioFase.DestivarMusica();


    }

    /*IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.5f);
        
        fade.FadeOut();
        fade.fade.SetActive(true);

        yield return new WaitForSeconds(1f);
    }*/

    public void DialogoAposCena()
    {
        dialogoflashback.SetActive(false);
        dialogoAposCena.SetActive(true);
    }

    

    public void AtivaCena()
    {
        CenaFlashBack.Play();
    }

    public void AtivaCenaInjecao()
    {
        cenainjecao.Play();
    }
    public void DesativaCenaInjecao()
    {
        cenainjecao.Stop();
    }

}
