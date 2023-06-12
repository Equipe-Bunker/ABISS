using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFase : MonoBehaviour
{
    public bool inimigoViuPlayer;
    public AudioClip[] audioClipsAmbientacao;
    public AudioClip[] audioClipsCombate;
    

    private AudioClip[] atualAudioClips;
    private int currentClipIndex;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        atualAudioClips = audioClipsAmbientacao;
        PlayRandomAudio();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayRandomAudio()
    {
        int index = Random.Range(0, atualAudioClips.Length);
        currentClipIndex = index;
        audioSource.clip = atualAudioClips[index];
        audioSource.Play();
    }




    
    // Update is called once per frame
    void Update()
    {

        if (!audioSource.isPlaying)
        {
            if (currentClipIndex == atualAudioClips.Length - 1)
            {
                currentClipIndex = 0;
            }
            else
            {
                currentClipIndex++;
            }
            audioSource.clip = atualAudioClips[currentClipIndex];
            audioSource.Play();
        }

        // Verifica se o inimigo está vendo o jogador
        if (inimigoViuPlayer)
        {
            // Toca o áudio do array 2
            if (atualAudioClips != audioClipsCombate)
            {
                atualAudioClips = audioClipsCombate;
                PlayRandomAudio();
            }
        }
        else
        {
            // Toca o áudio do array 1
            if (atualAudioClips != audioClipsAmbientacao)
            {
                atualAudioClips = audioClipsAmbientacao;
                PlayRandomAudio();
            }
        }


        /*if (Input.GetKeyDown(KeyCode.P))
        {
            MudarAudioClips();
        }*/
        
    }

    public void MudarAudioClips()
    {
        if (atualAudioClips == audioClipsAmbientacao)
        {
            atualAudioClips = audioClipsCombate;
        }
        else
        {
            atualAudioClips = audioClipsAmbientacao;
        }
        PlayRandomAudio();
    }


    

    // Método para ser chamado pelo inimigo quando ele ver o jogador
    public void EnemySawPlayer()
    {
        inimigoViuPlayer = true;
    }

    // Método para ser chamado pelo inimigo quando ele perder o jogador de vista
    public void EnemyLostPlayer()
    {
        inimigoViuPlayer = false;
    }



    public void AudioAmbientacao()
    {
        atualAudioClips = audioClipsAmbientacao;
        PlayRandomAudio();
    }
    
    public void AudioCombate()
    {
        if (atualAudioClips == audioClipsAmbientacao)
        {
            atualAudioClips = audioClipsCombate;
        }
        PlayRandomAudio();
    }
    public void DestivarMusica()
    {
        audioSource.enabled = false;
    }
    public void AtivarMusica()
    {
        audioSource.enabled = true;
    }

}
