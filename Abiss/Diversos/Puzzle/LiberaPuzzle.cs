using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LiberaPuzzle : MonoBehaviour
{
    public GameObject[] luzesAtivas;
    public int geradoresLigados;
    public bool ativaPuzzle, utilizavel;
    public GameObject interagir, abrirCanvas, mensagem;
    public TextMeshProUGUI textMesh;
    public string texto;
    
    bool puzzlecompleto;
    
    // Start is called before the first frame update
    void Start()
    {
        //puzzlecompleto = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(luzesAtivas[0].activeSelf == true)
        {
            geradoresLigados++;
        }
        if (luzesAtivas[1].activeSelf == true)
        {
            geradoresLigados++;
        }
        if (luzesAtivas[2].activeSelf == true)
        {
            geradoresLigados++;
        }*/

        if (geradoresLigados == 3 )
        {
            Debug.Log("pode ativar puzzle");
            if (Input.GetKeyDown(KeyCode.E) && utilizavel)
            {
                ativaPuzzle = true;
                AtivaGame();
            }
        }

       // Deixar uma mensagem que falta energia quando tentar interagir com menos de 3 geradores
        if(geradoresLigados < 3 && utilizavel && Input.GetKeyDown(KeyCode.E))
        {
            textMesh.text = texto;
            StartCoroutine(Mensagem(6f));
        }
    }


    public void AtivaGame()
    {
        if(ativaPuzzle == true)
        {
            abrirCanvas.SetActive(true);
        }
    }

    IEnumerator Mensagem(float tempo)
    {
        mensagem.SetActive(true);
        yield return new WaitForSeconds(tempo);
        mensagem.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            utilizavel = true;
            interagir.SetActive(true);
            Debug.Log(geradoresLigados);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            utilizavel = false;
            interagir.SetActive(false);
        }
    }
}
