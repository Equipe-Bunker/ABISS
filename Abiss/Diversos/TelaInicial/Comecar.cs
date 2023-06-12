using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comecar : MonoBehaviour
{
    
    Scene cenaAtual;
    public void Click(string _cena)
    {
        if (Input.GetButton("Fire3"))
        {
            cenaAtual = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            StartCoroutine(LoadScene("Fase1", true));
        }
        else
        {
            cenaAtual = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            StartCoroutine(LoadScene(_cena, false));
        }
    }

    IEnumerator LoadScene(string _cena, bool shift)
    {
        
        yield return new WaitForSeconds(1f);

        if (shift)
        {
            SceneManager.LoadSceneAsync("Principal");
        }
        AsyncOperation loadscene = SceneManager.LoadSceneAsync(_cena, LoadSceneMode.Additive);
        
        
        while(!loadscene.isDone){
            yield return null;
        }
        SceneManager.UnloadSceneAsync(cenaAtual.name);
    }


}