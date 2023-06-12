using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciaMenu : MonoBehaviour
{
    public string cena;
    public GameObject Options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Iniciar()
    {
        SceneManager.LoadScene(cena);
    }
    public void Sair()
    {
        //Para editor
        //Para game
        //Application.Quit();
    }
    public void ShowOP()
    {
        Options.SetActive(true);
    }
    public void HideOp()
    {
        Options.SetActive(false);
    }
}
