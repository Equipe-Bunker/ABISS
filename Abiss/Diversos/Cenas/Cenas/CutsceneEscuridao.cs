using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;

public class CutsceneEscuridao : MonoBehaviour
{
    bool podeApertar;
    public GameObject luz1, luz2;
    public Light2D luzGeral;

    public GameObject respawn, texto, escuridao, playerPrincipal, playerCena;

    public PlayableDirector cenaEscuridao;
    int i = 0;
    void Start()
    {
        //UniversalAdditionalLightData lightData = luzGeral.GetComponent<UniversalAdditionalLightData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (texto.activeSelf == true)
        {
            StartCoroutine(EsperaBotao2(0.5f));
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && podeApertar == true && i == 0)
        {
            ParaCenaEscuridao();
            i++;
        }
    }

    public void ChamaCenaEscuridao()
    {
        cenaEscuridao.Play();
        
        playerCena.SetActive(true);
        playerPrincipal.SetActive(false);

    }
    public void ParaCenaEscuridao()
    {
        cenaEscuridao.Stop();

        Destroy(escuridao);
        luz1.SetActive(false);
        luz2.SetActive(false);
        texto.SetActive(false);
        respawn.SetActive(true);
        luzGeral.intensity = 0.15f;
        playerPrincipal.SetActive(true);
        playerCena.SetActive(false);
    }

    IEnumerator EsperaBotao2(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        podeApertar = true;
        
        //texto.SetActive(true);
        
    }
}
