using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncostouTeste : MonoBehaviour
{
    [Tooltip("Quando o player encosta")][SerializeField][TextArea(1,3)] string textoI;
    [Tooltip("Quando o player des-encosta")][SerializeField][TextArea(1,3)] string textoO;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (textoI.Length > 3)
            {
                Enviar(textoI);
            }
            else
            {
                Enviar("Encostou: " + gameObject.name);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        /*if (col.CompareTag("Player"))
        {
            if (textoI.Length > 3)
            {
                Enviar(textoO);
            }
            else
            {
                Enviar("Des-encostou: " + gameObject.name);
            }
        }*/
    }

    void Enviar(string texto)
    {
        SalvarInformacoes.EscreverLinha(texto);
    }
}
