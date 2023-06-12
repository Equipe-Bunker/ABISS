using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLiquido : MonoBehaviour
{
    public VerificaLiquido verifica;
    [SerializeField] GameObject painel;
    [SerializeField] int numeroCorreto;
    [SerializeField] GameObject liquido;
    [SerializeField] GameObject[] pontoAlvo;
    [SerializeField] bool completo;
    int i = 0;
    public float speed;
    [SerializeField] bool comEnergia;
    private bool isMoving = false;
    bool correto;
    //bool ultimoCima, ultimoBaixo;
    void Start()
    {
        
    }
    void Update()
    {
        if(i == numeroCorreto - 1)
        {
            painel.SetActive(true);
            
            //correto = true;
            
        }
        if (i != numeroCorreto - 1)
        {
            painel.SetActive(false);
            //correto = false;
            Debug.Log(correto);
            
        }
    }

    /*public void PuzzleCorreto()
    {
        if (correto == true)
        {
            verifica.Acrescenta();
        }
        if(correto == false)
        {
            verifica.Diminui();
        }
    }*/
    public void BotaoCima()
    {
        if (!isMoving)
        {
            if(i < pontoAlvo.Length-1 )
            {
                i++;
                isMoving = true;
                StartCoroutine(MoverObjeto());

            }
            

        }
        


    }

    public void BotaoBaixo()
    {
        if (!isMoving )
        {
            if(i > pontoAlvo.Length - pontoAlvo.Length)
            {
                i--;
                isMoving = true;
                StartCoroutine(MoverObjeto());
            }
            /*if (i == pontoAlvo.Length)
            {
                Debug.Log("Ultimo de Cima");
                ultimoCima = true;
                botaoBaixo.interactable = false;
            }*/

        }



    }
    IEnumerator MoverObjeto()
    {
        while (liquido.transform.position != pontoAlvo[i].transform.position)
        {
            liquido.transform.position = Vector3.MoveTowards(liquido.transform.position, pontoAlvo[i].transform.position, speed * Time.deltaTime);
            yield return null;
        }
        //Debug.Log(i);
        isMoving = false;
        
    }

    

   

}
