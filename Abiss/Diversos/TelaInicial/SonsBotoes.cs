using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsBotoes : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip somSelecionado, somClic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivaSomSelect()
    {
        audioSource.clip = somSelecionado;
        audioSource.Play();
    }
    public void AtivaSomClic()
    {
        audioSource.clip = somClic;
        audioSource.Play();
    }
}
