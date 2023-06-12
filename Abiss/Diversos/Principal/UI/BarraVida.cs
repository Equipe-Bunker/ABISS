using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarraVida : MonoBehaviour
{
    Animator anim;
    public TextMeshProUGUI textoBarra;
    //public int barra;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    
    public void BarraVerde()
    {
        textoBarra.text = "Status / Bom";


        /*Debug.Log("Vida CHEIA");
        anim.SetBool("VidaCheia", true);
        anim.SetBool("VidaMedia", false);
        anim.SetBool("VidaBaixa", false);*/
    }

    public void BarraAmarela()
    {
        textoBarra.text = "Status / Atenção";


        /*Debug.Log("Vida Media");
        anim.SetBool("VidaCheia", false);
        anim.SetBool("VidaMedia", true);
        anim.SetBool("VidaBaixa", false);*/
    }

    public void BarraVermelha()
    {
        textoBarra.text = "Status / Perigo";

        /*Debug.Log("Vida Baixa");
        anim.SetBool("VidaCheia", false);
        anim.SetBool("VidaMedia", false);
        anim.SetBool("VidaBaixa", true);*/
    }
}
