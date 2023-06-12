using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControle : MonoBehaviour
{
    //public GameObject audioCombate;
    public AudioSource audioSourceMusicaDeFundo;

    public AudioClip[] musicasDeFundo;
    public AudioClip combate;
    public bool mCombate;

    int IndexMusica;

    // Start is called before the first frame update
    void Start()
    {

        IndexMusica = 0;
        AudioClip musicaMenu = musicasDeFundo[IndexMusica];
        //AudioClip musicaMenuLoop = musicasDeFundo[1];
        audioSourceMusicaDeFundo.clip = musicaMenu;
        //audioSourceMusicaDeFundo.loop = musicaMenuLoop;
        //audioSourceMusicaDeFundo.loop = true;

        audioSourceMusicaDeFundo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        MusicaAmbiente();
    }

    public void MusicaCombate()
    {
         audioSourceMusicaDeFundo.clip = combate;
         audioSourceMusicaDeFundo.loop = true;
         audioSourceMusicaDeFundo.Play();

    }

    public void MusicaAmbiente()
    {

        
        if (!audioSourceMusicaDeFundo.isPlaying)
        {
            IndexMusica = 1;
            AudioClip musicaMenu = musicasDeFundo[IndexMusica];
            audioSourceMusicaDeFundo.clip = musicaMenu;
            audioSourceMusicaDeFundo.loop = true;
            audioSourceMusicaDeFundo.Play();
            
            

        }
        
        
    }

}
