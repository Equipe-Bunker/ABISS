using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AtivaCenaQueda : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject Camera, dialogo;
    bool tocando;
    int n = 0;
    Player player;

    public GameObject playerPrincipal, pontoTeleporte;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tocando == true)
        {
            Ativacena();
        }
        
    }

    public void Ativacena()
    {
        n++;
        if (n ==1)
        {
            player.SetParado(true);
            playableDirector.Play();
            playerPrincipal.transform.position = pontoTeleporte.transform.position;
            StartCoroutine(DestravaPlayer());

        }
        
    }

    IEnumerator DestravaPlayer()
    {
        yield return new WaitForSeconds(4.95f);
        //player.SetParado(false);
        //npc.SetActive(true);
        Camera.SetActive(false);
        dialogo.SetActive(true);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.GetComponent<Player>();
            tocando = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = null;
            tocando = false;
        }
    }
}
