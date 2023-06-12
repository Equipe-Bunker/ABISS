using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextoConfig : MonoBehaviour
{
    Scene cenaAtual;
    //public GameObject txt1, txt2, txt3, txt4, txt5, txt6;
    //public GameObject btn1, btn2, btn3, btn4, btn5, btn6;

    bool b1, b2, b3, b4, b5;
    public string _cena;

    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(EsperaBotao1());
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E) && b1 == true)
        {
            Passa1();
        }

        if (Input.GetKeyDown(KeyCode.E) && b2 == true)
        {
            Passa2();
        }

        if (Input.GetKeyDown(KeyCode.E) && b3 == true)
        {
            Passa3();
        }

        if (Input.GetKeyDown(KeyCode.E) && b4 == true)
        {
            Passa4();
        }*/

        if (Input.GetKeyDown(KeyCode.E))
        {
            cenaAtual = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            StartCoroutine(LoadScene(_cena));
        }

    }


    /*public void Passa1()
    {

        
        txt1.SetActive(false);
        txt2.SetActive(true);

        StartCoroutine(EsperaBotao2());
        btn1.SetActive(false);


    }

    public void Passa2()
    {
        
        txt2.SetActive(false);
        txt3.SetActive(true);

        StartCoroutine(EsperaBotao3());
        btn2.SetActive(false);


    }

    public void Passa3()
    {
        

        txt3.SetActive(false);
        txt4.SetActive(true);

        StartCoroutine(EsperaBotao4());
        btn3.SetActive(false);


    }

    public void Passa4()
    {
        

        txt4.SetActive(false);
        txt5.SetActive(true);

        StartCoroutine(EsperaBotao5());
        btn4.SetActive(false);

    }
    public void Passa5()
    {
        

        txt5.SetActive(false);
        txt6.SetActive(true);

        StartCoroutine(EsperaBotao6());
        btn5.SetActive(false);

    }





    IEnumerator EsperaBotao1()
    {
        b1 = true;
        yield return new WaitForSeconds(5f);
        btn1.SetActive(true);
    }
    IEnumerator EsperaBotao2()
    {
        b2 = true;
        b1 = false;
        yield return new WaitForSeconds(6f);
        btn2.SetActive(true);
    }

    IEnumerator EsperaBotao3()
    {
        b3 = true;
        b2 = false;
        yield return new WaitForSeconds(8f);
        btn3.SetActive(true);
    }
    IEnumerator EsperaBotao4()
    {
        b4 = true;
        b3 = false;
        yield return new WaitForSeconds(9f);
        btn4.SetActive(true);
    }

    IEnumerator EsperaBotao5()
    {
        b5 = true;
        b4 = false;
        yield return new WaitForSeconds(9f);
        btn5.SetActive(true);
    }

    IEnumerator EsperaBotao6()
    {
        b5 = true;
        b4 = false;
        yield return new WaitForSeconds(5f);
        btn6.SetActive(true);
    }*/

    public void PassarCena()
    {
        
        cenaAtual = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        StartCoroutine(LoadScene(_cena));
        
        
    }

    IEnumerator LoadScene(string _cena)
    {

        yield return new WaitForSeconds(1f);

        SceneManager.LoadSceneAsync("Principal");
        AsyncOperation loadscene = SceneManager.LoadSceneAsync(_cena, LoadSceneMode.Additive);


        while (!loadscene.isDone)
        {
            yield return null;
        }
        SceneManager.UnloadSceneAsync(cenaAtual.name);
    }

}
