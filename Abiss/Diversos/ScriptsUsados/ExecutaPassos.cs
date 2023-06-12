using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutaPassos : MonoBehaviour
{
    public AudioSource somPassos;
    public AudioClip somNormal;
    public AudioClip somAgua;
    private bool estaNaZona = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Passos()
    {
        somPassos.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("agua"))
        {
            // O jogador entrou na zona
            estaNaZona = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("agua"))
        {
            // O jogador saiu da zona
            estaNaZona = false;
        }
    }
}
