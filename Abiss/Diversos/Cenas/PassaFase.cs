using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassaFase : MonoBehaviour
{

    Scene cenaAtual;
    public string _cena;
    public void PassarCena()
    {
        
        cenaAtual = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        StartCoroutine(LoadScene(_cena));
    }

    IEnumerator LoadScene(string _cena)
    {

        yield return new WaitForSeconds(6f);
        SalvarInformacoes.EscreverLinha("\nEntrando na " + _cena + "\n");

        AsyncOperation loadscene = SceneManager.LoadSceneAsync(_cena);


        while (!loadscene.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(cenaAtual.name);
    
    }
    // Start is called before the first frame update
    void Start()
    {
        cenaAtual = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        StartCoroutine(LoadScene(_cena));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            cenaAtual = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            StartCoroutine(LoadScene(_cena));
        }
    }
}
