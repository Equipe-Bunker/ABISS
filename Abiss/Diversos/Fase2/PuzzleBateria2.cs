using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleBateria2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int ativo;
    public GameObject portaFase3;
    //public GameObject luz1, luz2, luz3;
    public GameObject ativaCena;

    //public UnityEvent evento;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*switch (ativo)
        {
            case 1:
                luz1.SetActive(true);
                
                break;
            case 2:
                luz2.SetActive(true);
                break;
            case 3:
                luz3.SetActive(true);
                break;

        }*/

        


        if (ativo == 3)
        {
            AtivaPorta();
        }
    }

    public void AtivaPorta()
    {
        portaFase3.SetActive(true);
        portaFase3.GetComponent<BoxCollider2D>().enabled = true;
        ativaCena.SetActive(true);
        StartCoroutine(AtivaFase3());
    }

    IEnumerator AtivaFase3()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("fase 3");

    }

}
