using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISair : MonoBehaviour
{
    public void SairParaTelaInicial(){
        Time.timeScale = 1;
        StartCoroutine(CarregarCena());
    }

    IEnumerator CarregarCena(){

        AsyncOperation cena = SceneManager.LoadSceneAsync("Load", LoadSceneMode.Single);

        while(!cena.isDone){
            yield return null;
        }
    }
}
