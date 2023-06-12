using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carregar : MonoBehaviour
{
    bool podeInteragir = false;
    public GameObject Player;
    public string CenaCarregar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podeInteragir == true && Input.GetKeyDown(KeyCode.E))
        {
            Player.GetComponent<SalvarPosic>().SalvarLocalizacao();
            SceneManager.LoadScene(CenaCarregar);

        }
    }

    void OnTriggerEnter2D()
    {
        podeInteragir = true;
    }
    void OnTriggerExit2D()
    {
        podeInteragir = false;
    }


    //Função Opcional 

    void OnGUI()
    {
        if(podeInteragir == true)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 20, 200, 30), "Pressione 'E'");

        }
    }
}
