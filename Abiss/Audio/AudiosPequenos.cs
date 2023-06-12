using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPequenos : MonoBehaviour
{
    public AudioSource audioSource, audioSourceSimultaneo;

    public AudioClip inventario, coletaItem, coletaDocumento;
    public AudioClip mira, recarga, tiro, elevador, barulhoQuadro, bip, portaMadeira, portaEletronica, armario, dialogo, escadas, bipConfirma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SomTiro()
    {
        audioSource.clip = tiro;
        audioSource.Play();
    }

    public void SomRecarga()
    {
        audioSource.clip = recarga;
        audioSource.Play();
    }

    public void SomElevador()
    {
        audioSource.clip = elevador;
        audioSource.Play();
    }

    public void BarulhoQuandro()
    {
        audioSource.clip = barulhoQuadro;
        audioSource.Play();
    }

    public void SonsDialogos()
    {
        audioSource.clip = dialogo;
        audioSource.Play();
        

    }
    public void DesativaDialogos()
    {
        audioSource.clip = dialogo;
        audioSource.Stop();

    }

    public void Bip()
    {
        audioSource.clip = bip;
        audioSource.Play();
    }

    public void BipConfirma()
    {
        audioSource.clip = bipConfirma;
        audioSource.Play();
    }

    public void PortaMadeira()
    {
        audioSource.clip = portaMadeira;
        audioSource.Play();
    }

    public void PortaEletronica()
    {
        audioSource.clip = portaEletronica;
        audioSource.Play();
    }

    public void AbrirInventario()
    {
        audioSource.clip = inventario;
        audioSource.Play();
    }

    public void ColetaItem()
    {
        audioSource.clip = coletaItem;
        audioSource.Play();
    }

    public void ColetaDocumento()
    {
        audioSource.clip = coletaDocumento;
        audioSource.Play();
    }

    public void Escadas()
    {
        audioSource.clip = escadas;
        audioSource.Play();
    }

    /*public void SomMira()
    {
        audioSourceSimultaneo.clip = mira;
        audioSourceSimultaneo.Play();
        //StartCoroutine(AtivaSomMira());
        Debug.Log("Mira Som");
    }
    */
    /*public IEnumerator AtivaSomMira()
    {
        yield return new WaitForSeconds(0.1f);
        audioSourceSimultaneo.clip = mira;
        audioSourceSimultaneo.Play();
    }*/

    public void Cadeado()
    {

    }

    public void MenuPause()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
