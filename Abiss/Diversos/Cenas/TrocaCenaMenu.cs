using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCenaMenu : MonoBehaviour
{
    public string nomeCena;

    public void MudaCena()
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void Sair()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
