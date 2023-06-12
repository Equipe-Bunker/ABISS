using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJogador : MonoBehaviour
{
    bool receberDano;
    public Image barraVida;
    public static float vidaMaxima = 10f;
    public static float vidaAtual;


    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vidaAtual / vidaMaxima;
    }

    public void ReceberDano()
    {
        receberDano = true;
        vidaAtual -= 1;

        if (receberDano == true)
        {
            Debug.Log("Recebeu Dano");
        }
            if (vidaAtual <= 0)
        {
            Debug.Log("Game Over");

        }
    }

}
