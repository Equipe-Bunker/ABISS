using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escadas : MonoBehaviour
{
    [SerializeField] Transform destino;
    AudiosPequenos au;
    bool podeInteragir;
    public GameObject interagir;
    Player player;
    [SerializeField] float tempo;
    public Animator fade;
    GameObject objetoFade;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        au = FindObjectOfType<AudiosPequenos>();
        objetoFade = GameObject.FindGameObjectWithTag("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && podeInteragir)
        {
            
            fade.SetBool("Ativa", true);
            StartCoroutine(Subindo());


        }
    }
    IEnumerator Subindo()
    {
        if (player)
        {
            player.GetComponent<Player>().SetParado(true);
            player.GetComponent<Player>().playerRig.velocity = Vector2.zero;
        }


        au.Escadas();
        yield return new WaitForSeconds(tempo);
        fade.SetBool("Ativa", false);
        if (player)
        {
            player.transform.position = destino.position;
            player.GetComponent<Player>().SetParado(false);

        }



    }
    public void Fade()
    {
        StartCoroutine(Animacao());
    }

    IEnumerator Animacao()
    {
        fade.SetBool("Ativa", true);
        yield return new WaitForSeconds(0.2f);
        fade.SetBool("Ativa", false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
            podeInteragir = true;
            interagir.SetActive(true);
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
