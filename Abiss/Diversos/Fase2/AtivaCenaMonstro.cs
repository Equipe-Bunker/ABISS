using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AtivaCenaMonstro : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject Camera, destrocoVai, destrocoFica, porta, monstroCorredor, perseguidor;
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
        yield return new WaitForSeconds(11f);
        player.SetParado(false);
        destrocoVai.SetActive(false);
        destrocoFica.SetActive(true);
        porta.SetActive(true);
        monstroCorredor.SetActive(true);
        perseguidor.SetActive(true);

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
