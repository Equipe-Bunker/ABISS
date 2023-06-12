using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTutorial : MonoBehaviour
{
    public bool comBotao;
    bool tocando = false;
    public GameObject canvas, botao;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(Aparece());
    }

    // Update is called once per frame
    void Update()
    {
        if (comBotao == true && tocando == true && i == 1)
        {
            
        }

        if (tocando == true && i >= 1)
        {
            StartCoroutine(Aparece());
        }
    }

    IEnumerator Aparece()
    {

        yield return new WaitForSeconds(0.5f);
        canvas.SetActive(true);
        //botao.SetActive(true);
        if (comBotao == true)
        {
            yield return new WaitForSeconds(2f);
            botao.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(8f);
            canvas.SetActive(false);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            i++;
            tocando = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tocando = false;
        }
    }

}
