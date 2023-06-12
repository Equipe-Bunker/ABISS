using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroiPonto : MonoBehaviour
{
    InimigoPerseguidor inimigoPerseguidor;


    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Instanciaou");
        inimigoPerseguidor = FindObjectOfType<InimigoPerseguidor>();
        Destroy(gameObject, inimigoPerseguidor.tempoPerseguicao);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
