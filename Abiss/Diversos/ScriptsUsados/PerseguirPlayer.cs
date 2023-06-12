using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguirPlayer : MonoBehaviour
{
    public GameObject inimigo;
    InimigoPerseguidor inimigoPerseguidor;
    public bool enfermaria, vestiarios, salaDeArma, refeitorio, cozinha, deposito, incubadora, salaCirurgia, salaSeguranca, servidores, salaTeste, salaFria, salaEnsaio, salaInjecao;

    //corredores
    public bool corredor1A, corredor1B, corredor1C, corredor1D, corredor2A, corredor2B, corredor3A, corredor3B;

    public bool playerEstaAqui;
    
    //corredores
    public GameObject[] aparicaoCorredor1A, aparicaoCorredor1B, aparicaoCorredor1C, aparicaoCorredor1D;
    //salas
    public GameObject[] aparicaoIncubadora;
    // Start is called before the first frame update
    void Start()
    {
        inimigoPerseguidor = FindObjectOfType<InimigoPerseguidor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoverInimigo()
    {
        MoverParaCorredor1A();
        MoverParaCorredor1B();
        MoverParaCorredor1C();
        MoverParaCorredor1D();

        //salas
        MoverParaIncubadora();


    }
    public void MoverParaCorredor1A()
    {
        if(inimigoPerseguidor.perseguicao == true)
        {
            int i = Random.Range(0, aparicaoCorredor1A.Length);
            GameObject pontoAleatorio = aparicaoCorredor1A[i];
            inimigo.transform.position = pontoAleatorio.transform.position;
        }
    }
    public void MoverParaCorredor1B()
    {
        if (playerEstaAqui = true && inimigoPerseguidor.perseguicao == true)
        {
            int i = Random.Range(0, aparicaoCorredor1B.Length);
            GameObject pontoAleatorio = aparicaoCorredor1B[i];
            inimigo.transform.position = pontoAleatorio.transform.position;
        }
    }

    public void MoverParaCorredor1C()
    {
        if (playerEstaAqui = true && inimigoPerseguidor.perseguicao == true)
        {
            int i = Random.Range(0, aparicaoCorredor1C.Length);
            GameObject pontoAleatorio = aparicaoCorredor1C[i];
            inimigo.transform.position = pontoAleatorio.transform.position;
        }
    }

    public void MoverParaCorredor1D()
    {
        if (playerEstaAqui = true && inimigoPerseguidor.perseguicao == true)
        {
            int i = Random.Range(0, aparicaoCorredor1D.Length);
            GameObject pontoAleatorio = aparicaoCorredor1D[i];
            inimigo.transform.position = pontoAleatorio.transform.position;
        }
    }
    public void MoverParaIncubadora()
    {
        if (playerEstaAqui = true && inimigoPerseguidor.perseguicao == true)
        {
            int i = Random.Range(0, aparicaoIncubadora.Length);
            GameObject pontoAleatorio = aparicaoIncubadora[i];
            inimigo.transform.position = pontoAleatorio.transform.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && incubadora == true)
        {
            
            playerEstaAqui = true;

            

        }

        if (col.CompareTag("Player") && enfermaria == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && vestiarios == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaDeArma == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && refeitorio == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && cozinha == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && deposito == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaCirurgia == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaSeguranca == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && servidores == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaTeste == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaFria == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaEnsaio == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && salaInjecao == true)
        {
            playerEstaAqui = true;

        }

        //corredores

        if (col.CompareTag("Player") && corredor1A == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor1B == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor1C == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor1D == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor2A == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor2B == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor3A == true)
        {
            playerEstaAqui = true;

        }

        if (col.CompareTag("Player") && corredor3B == true)
        {
            playerEstaAqui = true;

        }

    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && incubadora == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && enfermaria == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && vestiarios == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaDeArma == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && refeitorio == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && cozinha == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && deposito == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaCirurgia == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaSeguranca == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && servidores == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaTeste == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaFria == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaEnsaio == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && salaInjecao == true)
        {
            playerEstaAqui = false;

        }



        //corredores

        if (col.CompareTag("Player") && corredor1A == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor1B == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor1C == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor1D == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor2A == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor2B == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor3A == true)
        {
            playerEstaAqui = false;

        }

        if (col.CompareTag("Player") && corredor3B == true)
        {

            playerEstaAqui = false;
        }


    }


}
