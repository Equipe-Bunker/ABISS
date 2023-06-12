using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AtivaDocumento : MonoBehaviour
{
    //public Button documento1, documento2, documento3, documento4, documento5, documento6, documento7, documento8, documento9, documento10;
    bool coletou, coletou1, coletou2, coletou3, coletou4, coletou5, coletou6, coletou7, coletou8, coletou9, coletou10;
    public Button[] documento;
    DocumentoConfig[] docConfig;
    public TextMeshProUGUI[] textTitulo;
    public string[] titulo;


    void Start()
    {
        docConfig = FindObjectsOfType<DocumentoConfig>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coletou == true)
        {
            textTitulo[0].text = titulo[0];
        }
        if (coletou1 == true)
        {
            textTitulo[1].text = titulo[1];
        }
        if (coletou2 == true)
        {
            textTitulo[2].text = titulo[2];
        } 
        if (coletou3 == true)
        {
            textTitulo[3].text = titulo[3];
        }

        if (coletou4 == true)
        {
            textTitulo[4].text = titulo[4];
        }
        if (coletou5 == true)
        {
            textTitulo[5].text = titulo[5];
        }
        if (coletou6 == true)
        {
            textTitulo[6].text = titulo[6];
        }
        if (coletou7 == true)
        {
            textTitulo[7].text = titulo[7];
        }
        if (coletou8 == true)
        {
            textTitulo[8].text = titulo[8];
        }
        if (coletou9 == true)
        {
            textTitulo[9].text = titulo[9];
        }
        if (coletou10 == true)
        {
            textTitulo[10].text = titulo[10];
        }
    }


   



    public void load(bool[] coletou)
{
         if (coletou[0])
        {
        ativaDoc1();
        }
        if (coletou[1])
        {
            ativaDoc2();
        }
        if (coletou[2])
        {
            ativaDoc3();
        }
        if (coletou[3])
        {
            ativaDoc4();
        }
        if (coletou[4])
        {
            ativaDoc5();
        }
        if (coletou[5])
        {
            Debug.Log("Precisa colocar aqui o ativaDoc6");
        }
        if (coletou[6])
        {
            Debug.Log("Precisa colocar aqui o ativaDoc7");
        }
        if (coletou[7])
        {
            Debug.Log("Precisa colocar aqui o ativaDoc8");
        }
        if (coletou[8])
        {
            Debug.Log("Precisa colocar aqui o ativaDoc9");
        }
        if (coletou[9])
        {
            Debug.Log("Precisa colocar aqui o ativaDoc10");
        }
        else if(coletou.Length > 10) { Debug.Log("Precisa configurar os novos documentos aqui"); }
 }
public bool[] save() { 
    {
        bool[] coletados = new bool[documento.Length];
        for (int a = 0; a < documento.Length; a++)
        {
            coletados[a] = documento[a].GetComponent<DocumentoConfig>().coletou;
        }
        return coletados;
    }
}
public void ativaDoc()
    {
        coletou = true;
        documento[0].interactable = true;
        documento[0].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc1()
    {
        coletou1 = true;
        documento[1].interactable = true;
        documento[1].GetComponent<DocumentoConfig>().coletou = true;
    }
   public void ativaDoc2()
    {
        coletou2 = true;
        documento[2].interactable = true;
        documento[2].GetComponent<DocumentoConfig>().coletou = true;
    }
    public void ativaDoc3()
    {
        coletou3 = true;
        documento[3].interactable = true;
        documento[3].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc4()
    {
        coletou4 = true;
        documento[4].interactable = true;
        documento[4].GetComponent<DocumentoConfig>().coletou = true;
    }
    public void ativaDoc5()
    {
        coletou5 = true;
        documento[5].interactable = true;
        documento[5].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc6()
    {
        coletou6 = true;
        documento[6].interactable = true;
        documento[6].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc7()
    {
        coletou7 = true;
        documento[7].interactable = true;
        documento[7].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc8()
    {
        coletou8 = true;
        documento[8].interactable = true;
        documento[8].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc9()
    {
        coletou9 = true;
        documento[9].interactable = true;
        documento[9].GetComponent<DocumentoConfig>().coletou = true;
    }

    public void ativaDoc10()
    {
        coletou10 = true;
        documento[10].interactable = true;
        documento[10].GetComponent<DocumentoConfig>().coletou = true;
    }

}


