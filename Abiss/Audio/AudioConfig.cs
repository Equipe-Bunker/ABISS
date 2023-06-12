using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
   /* [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicaSlider;
    [SerializeField] Slider efeitoSlider;

    const string AUDIO_MASTER = "AudioMaster";
    const string AUDIO_MUSICA = "AudioMusica";
    const string AUDIO_EFEITOS = "AudioEfeitos";

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetarVolumeMaster);
        musicaSlider.onValueChanged.AddListener(SetarVolumeMusica);
        efeitoSlider.onValueChanged.AddListener(SetarVolumeEfeito);
    }

    public void SetarVolumeMaster(float valor)
    {
        float volume;
        if(valor < 0.0001)
        {
            volume = 0.0001f;
        }
        else
        {
            volume = valor;
        }
        mixer.SetFloat(AUDIO_MASTER, volume);
    }

    public void SetarVolumeMusica(float valor)
    {
        float volume;
        if (valor < 0.0001)
        {
            volume = 0.0001f;
        }
        else
        {
            volume = valor;
        }
        mixer.SetFloat(AUDIO_MUSICA, volume);
    }

    public void SetarVolumeEfeito(float valor)
    {
        float volume;
        if (valor < 0.0001)
        {
            volume = 0.0001f;
        }
        else
        {
            volume = valor;
        }
        mixer.SetFloat(AUDIO_EFEITOS, Mathf.Log10(volume) * 20);
    }*/

    public void MudarValor(Slider slider)
    {
        switch (slider.value)
        {
            case 0:
                mixer.SetFloat("Musica", -30);
                break;

            case 1:
                mixer.SetFloat("Musica", -5);
                break;
            
            case 2:
                mixer.SetFloat("Musica", 0);
                break;

            case 3:
                mixer.SetFloat("Musica", 4);
                break;

            case 4:
                mixer.SetFloat("Musica", 7);
                break;

            case 5:
                mixer.SetFloat("Musica", 10);
                break;
        }

        switch (slider.value)
        {
            case 0:
                mixer.SetFloat("Efeitos", -30);
                break;

            case 1:
                mixer.SetFloat("Efeitos", -5);
                break;

            case 2:
                mixer.SetFloat("Efeitos", 0);
                break;

            case 3:
                mixer.SetFloat("Efeitos", 4);
                break;

            case 4:
                mixer.SetFloat("Efeitos", 7);
                break;

            case 5:
                mixer.SetFloat("Efeitos", 10);
                break;
        }


        switch (slider.value)
        {
            case 0:
                mixer.SetFloat("Master", -30);
                break;

            case 1:
                mixer.SetFloat("Master", -5);
                break;

            case 2:
                mixer.SetFloat("Master", 1);
                break;

            case 3:
                mixer.SetFloat("Master", 4);
                break;

            case 4:
                mixer.SetFloat("Master", 7);
                break;

            case 5:
                mixer.SetFloat("Master", 10);
                break;
        }


    }


}
