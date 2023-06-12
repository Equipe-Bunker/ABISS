using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassaTextoCutScene : MonoBehaviour
{
    
    
    public TextMeshProUGUI texto;
    char[] ctr;
    public float velocidadeDigitacao;
    
    [TextArea(3, 5)]
    public string falaTxt;

    // Start is called before the first frame update
    void Start()
    {
        
        ctr = falaTxt.ToCharArray();
        StartCoroutine(TipoDialogo());
    }

    // Update is called once per frame
    void Update()
    {

            
    }

    IEnumerator TipoDialogo() // Animação do dialogo sendo mostrado
    {
        int count = 0;
        while (count < ctr.Length)
        {
            yield return new WaitForSeconds(velocidadeDigitacao);
            texto.text += ctr[count];
            count++;
        }
        

    }

    

}
