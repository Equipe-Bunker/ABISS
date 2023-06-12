using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infeccao : MonoBehaviour
{
    //[SerializeField] int dano;
    Player player;
    int i, a;
    bool tocou, morte, jaMorreu;
    public float tempoMorte;
    private float tempoAtual = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tocou == true && player.luzAtiva == false)
        {
            tempoAtual += Time.deltaTime;
            i++;
            if (i == 1)
            {

                StartCoroutine(DanoInfinito());
                tempoAtual += Time.deltaTime;
                
                if (morte == true)
                {
                    a++;
                    if (tempoAtual >= tempoMorte )
                    {
                        Debug.Log("Morte");
                        player.AnimacaoMorte();
                        //jaMorreu = true;
                        Debug.Log(a);
                    }

                }
                else
                {
                    StopCoroutine(DanoInfinito());
                    tempoAtual = 0f;
                }
            }
            
        }
        else if(tocou == false && player.luzAtiva == false)
        {
            tempoAtual = 0f;
            i = 0;
            StopCoroutine(DanoInfinito());

            player.AnimacaoParaAlucinacao();
            //Debug.Log("Animação infeccao encerrada");

        }
        else if (player.luzAtiva == true)
        {
            tempoAtual = 0f;
            i = 0;
            StopCoroutine(DanoInfinito());

            player.AnimacaoParaAlucinacao();
            //Debug.Log("Animação infeccao encerrada");
        }

        else
        {
            i = 0;
            StopCoroutine(DanoInfinito());
            player.AnimacaoParaAlucinacao();
            tempoAtual = 0f;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tocou = true;
            tempoAtual = 0f;
        }

    }

    /*private void OnTriggerStay2D(Collider2D col)
    {
        
        if (tocou == true)
        {
            tempoAtual += Time.deltaTime;
            Debug.Log("Faz alguma coisa peloi amor de deus");
            if (tempoAtual >= tempoMorte)
            {
                // Aqui você pode ativar algo após o tempo determinado
                Debug.Log("Morte");
                player.SetVida(0);
                Debug.Log(tempoAtual);
            }
        }


    }*/

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tocou = false;
            i = 0;
            //player.luzAtiva = false;
            morte = false;
        }
        
    }

    



    IEnumerator DanoInfinito()
    {
        //animação infeccao
        
        yield return new WaitForSeconds(5);

        Debug.Log("Animação infeccao");
        player.AnimacaoAlucinacao();

        yield return new WaitForSeconds(tempoMorte);
        morte = true;
        
        i = 0;
    }

   



}
