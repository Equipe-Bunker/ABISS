using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UITesteInicio : MonoBehaviour
{
    [SerializeField] TMP_InputField nome;
    [SerializeField] GameObject errou;
    public void BotaoAQUI(string nomeCena) 
    {
        if (SalvarInformacoes.EscreverNome(nome.text))
        {
            StartCoroutine(IniciarGame(nomeCena));
        }
        else
        {
            errou.SetActive(true);
        }
    }

    IEnumerator IniciarGame(string nomeCena)
    {
        AsyncOperation loadscene = SceneManager.LoadSceneAsync(nomeCena);

        SalvarInformacoes.EscreverLinha("Começou na fase: " + nomeCena);

        while (!loadscene.isDone)
        {
            yield return null;
        }

        /*
        AsyncOperation principal = SceneManager.LoadSceneAsync("Principal");
        
        AsyncOperation loadscene = SceneManager.LoadSceneAsync(nomeCena, LoadSceneMode.Additive);


        while (!principal.isDone)
        {
            yield return null;
        }

        while (!loadscene.isDone)
        {
            yield return null;
        }
        */
    }
}
