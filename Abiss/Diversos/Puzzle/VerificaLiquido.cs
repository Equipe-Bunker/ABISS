using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaLiquido : MonoBehaviour
{
    int i;
    int add, ret;

    //AudiosPequenos audiosPequenos;
    public GameObject painel1, painel2, painel3;
    public GameObject portaReator, audioConfirmar, dialogo, painelPuzzle, console;
    // Start is called before the first frame update
    
    void Start()
    {
        //audiosPequenos = FindObjectOfType<AudiosPequenos>();
    }

    // Update is called once per frame
    void Update()
    {
        if(painel1.activeSelf && painel2.activeSelf && painel3.activeSelf)
        {
            
            Debug.Log("Puzzle Concluido");
            Concluido();
        }
        else
        {
            audioConfirmar.SetActive(false);
        }
    }

    public void Concluido()
    {
        portaReator.GetComponent<BoxCollider2D>().enabled = true;
        //audiosPequenos.BipConfirma();
        audioConfirmar.SetActive(true);
        console.SetActive(false);
        StartCoroutine(Desativa());

    }

    IEnumerator Desativa()
    {
        yield return new WaitForSeconds(2f);
        painelPuzzle.SetActive(false);
        dialogo.SetActive(true);
    }
}
