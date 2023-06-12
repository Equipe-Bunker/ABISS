using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DocumentoConfig : MonoBehaviour
{
    public bool coletou;
    public GameObject conteudo;
    public TextMeshProUGUI textoDocumento;
    //public Scrollbar scroll;
    //public string textTitulo;
    [TextArea(10,10)]
    public string texto;

    
    
    //int click = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AtivaConteudo()
    {

        
        textoDocumento.text = texto;
        conteudo.SetActive(true);
        //click ++;

    }



}
