using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AtivaCena1 : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject Camera;
    bool tocando;
    int n = 0;
    Player player;
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
        /*if (playableDirector.time > 12)
        {
            player.SetParado(false);
           //Camera.SetActive(false);
        }*/
    }

    public void Ativacena()
    {
        n++;
        if (n ==1)
        {
            player.SetParado(true);
            playableDirector.Play();
            StartCoroutine(DestravaPlayer());
        }
        
    }

    IEnumerator DestravaPlayer()
    {
        yield return new WaitForSeconds(8f);
        player.SetParado(false);

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
