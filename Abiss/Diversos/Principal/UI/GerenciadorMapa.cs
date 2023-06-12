using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GerenciadorMapa : MonoBehaviour
{
    //public bool playerEstaAqui;
    [SerializeField] MarcadorMapa marcador;

    //salas
    public bool enfermaria, vestiarios, salaDeArma, refeitorio, cozinha, deposito, incubadora, salaCirurgia, salaSeguranca, servidores, salaTeste, salaFria, salaEnsaio, salaInjecao;

    //corredores
    public bool corredor1A, corredor1B, corredor1C, corredor1D, corredor2A, corredor2B, corredor3A, corredor3B;

    
    // Start is called before the first frame update
    void Start()
    {
        if (!marcador)
        {
            marcador = FindObjectOfType<MarcadorMapa>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && incubadora == true)
        {
            marcador.incubadora.SetActive(true);
            
        }

        if (col.CompareTag("Player") && enfermaria == true)
        {
            marcador.enfermaria.SetActive(true);
            
        }

        if (col.CompareTag("Player") && vestiarios == true)
        {
            marcador.vestiarios.SetActive(true);

        }

        if (col.CompareTag("Player") && salaDeArma == true)
        {
            marcador.salaDeArma.SetActive(true);

        }

        if (col.CompareTag("Player") && refeitorio == true)
        {
            marcador.refeitorio.SetActive(true);

        }

        if (col.CompareTag("Player") && cozinha == true)
        {
            marcador.cozinha.SetActive(true);

        }

        if (col.CompareTag("Player") && deposito == true)
        {
            marcador.deposito.SetActive(true);

        }

        if (col.CompareTag("Player") && salaCirurgia == true)
        {
            marcador.salaCirurgia.SetActive(true);

        }

        if (col.CompareTag("Player") && salaSeguranca == true)
        {
            marcador.salaSeguranca.SetActive(true);

        }

        if (col.CompareTag("Player") && servidores == true)
        {
            marcador.servidores.SetActive(true);

        }

        if (col.CompareTag("Player") && salaTeste == true)
        {
            marcador.salaTeste.SetActive(true);

        }

        if (col.CompareTag("Player") && salaFria == true)
        {
            marcador.salaFria.SetActive(true);

        }
        
        if (col.CompareTag("Player") && salaEnsaio == true)
        {
            marcador.salaEnsaio.SetActive(true);

        }

        if (col.CompareTag("Player") && salaInjecao == true)
        {
            marcador.salaInjecao.SetActive(true);

        }

        //corredores

        if (col.CompareTag("Player") && corredor1A == true)
        {
            marcador.corredor1A.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor1B == true)
        {
            marcador.corredor1B.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor1C == true)
        {
            marcador.corredor1C.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor1D == true)
        {
            marcador.corredor1D.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor2A == true)
        {
            marcador.corredor2A.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor2B == true)
        {
            marcador.corredor2B.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor3A == true)
        {
            marcador.corredor3A.SetActive(true);

        }

        if (col.CompareTag("Player") && corredor3B == true)
        {
            marcador.corredor3B.SetActive(true);

        }

    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && incubadora == true)
        {
            marcador.incubadora.SetActive(false);

        }

        if (col.CompareTag("Player") && enfermaria == true)
        {
            marcador.enfermaria.SetActive(false);

        }

        if (col.CompareTag("Player") && vestiarios == true)
        {
            marcador.vestiarios.SetActive(false);

        }

        if (col.CompareTag("Player") && salaDeArma == true)
        {
            marcador.salaDeArma.SetActive(false);

        }

        if (col.CompareTag("Player") && refeitorio == true)
        {
            marcador.refeitorio.SetActive(false);

        }

        if (col.CompareTag("Player") && cozinha == true)
        {
            marcador.cozinha.SetActive(false);

        }

        if (col.CompareTag("Player") && deposito == true)
        {
            marcador.deposito.SetActive(false);

        }

        if (col.CompareTag("Player") && salaCirurgia == true)
        {
            marcador.salaCirurgia.SetActive(false);

        }

        if (col.CompareTag("Player") && salaSeguranca == true)
        {
            marcador.salaSeguranca.SetActive(false);

        }

        if (col.CompareTag("Player") && servidores == true)
        {
            marcador.servidores.SetActive(false);

        }

        if (col.CompareTag("Player") && salaTeste == true)
        {
            marcador.salaTeste.SetActive(false);

        }

        if (col.CompareTag("Player") && salaFria == true)
        {
            marcador.salaFria.SetActive(false);

        }

        if (col.CompareTag("Player") && salaEnsaio == true)
        {
            marcador.salaEnsaio.SetActive(false);

        }

        if (col.CompareTag("Player") && salaInjecao == true)
        {
            marcador.salaInjecao.SetActive(false);

        }



        //corredores

        if (col.CompareTag("Player") && corredor1A == true)
        {
            marcador.corredor1A.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor1B == true)
        {
            marcador.corredor1B.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor1C == true)
        {
            marcador.corredor1C.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor1D == true)
        {
            marcador.corredor1D.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor2A == true)
        {
            marcador.corredor2A.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor2B == true)
        {
            marcador.corredor2B.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor3A == true)
        {
            marcador.corredor3A.SetActive(false);

        }

        if (col.CompareTag("Player") && corredor3B == true)
        {
            marcador.corredor3B.SetActive(false);

        }


    }

}
