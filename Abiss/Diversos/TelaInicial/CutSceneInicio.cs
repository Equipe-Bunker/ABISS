using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneInicio : MonoBehaviour
{
    [Header("Configurações de Texto")]
    [Tooltip("Aqui você escreve o texto que voce quer, mas para cada texto tem que ter um \"textoUI\"")] [SerializeField] [TextArea(3,5)] String[] texto;
    [Tooltip("Coloque uma imagem que voce quer, precisa configurar no script em \"AtivarImagem\"")] [SerializeField] GameObject[] img;
    [Tooltip("Vai o TextMeshPro e repedinto para cada texto que coloca precisa ter um textoUI")] [SerializeField] TextMeshProUGUI[] textoUI;
    [Tooltip("Velocidade que o texto sera digitado")] [SerializeField] float velocidadeDigitacao;
    [Tooltip("Aviso que fica piscando quando acaba o texto")] [SerializeField] TextMeshProUGUI pressione;
    [Tooltip("Velocidade que pisca")][SerializeField] float oscillationSpeed;

    [Header("Configurações de Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

    [Header("Comfigurações da cena")]
    UnityEngine.SceneManagement.Scene cenaAtual;
    [Tooltip("Cena que ira carregar após a introduçao e cenas da tela de cheat")] [SerializeField] String[] cena;
    [Tooltip("UI das trapaças")] [SerializeField] GameObject cenaUI;
    [Tooltip("Oque recebera no cheat")] [SerializeField] GameObject[] prefabs;
    [SerializeField] Toggle toggleItens, toggleVida;

    //========= Outros
    int index = 0;
    float tempo1, tempoPular, alphaValue;

    private void Start()
    {
        AtivarImagem();
        ReproduzirAudio();
        textoUI[index].text = "";
        StartCoroutine(EscreverTexto());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            VerificarTexto();
        }

        //Carregar cheat
        if(Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J) && tempo1 > Time.time)
        {
            Debug.Log("Ativando...");
        }
        else if (tempo1 < Time.time && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J))
        {
            cenaUI.SetActive(true);
            tempo1 = Time.time + 10f;
        }
        else
        {
            tempo1 = Time.time + 3f;
        }

        if (textoUI[index].text == texto[index])
        {
            pressione.gameObject.SetActive(true);
            alphaValue = Mathf.PingPong(Time.time * oscillationSpeed, 1.5f);
            pressione.color = new Color(pressione.color.r, pressione.color.g, pressione.color.b, alphaValue);
        }
        else
        {
            pressione.gameObject.SetActive(false);
        }
    }

    IEnumerator EscreverTexto() // Vai digitar letra por letra do texto que estiver escrevendo no momento
    {
        foreach (char letra in texto[index].ToCharArray())
        {
            textoUI[index].text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }
    }

    public void VerificarTexto() //Vai verificar se pode passar ou concluir o texto
    {
        if (textoUI[index].text == texto[index] && tempoPular < Time.time) //Verifica se o texto esta completo e se acabou de completar o texto, onde tem 1 segundo
        {                                                                  //de delay para evitar pular sem querer o proximo texto
            if (index < texto.Length - 1) //Verifica se tem mais algum texto para escrever caso tenha ele vai executar o EscreverTexto de novo até chegar no final
            {
                ProximoTexto();
                AtivarImagem();
                ReproduzirAudio();
                StartCoroutine(EscreverTexto());
            }
            else //Caso não tenho mais nenhum ele executa aqui, por enquanto vazio ;-;
            {
                cenaAtual = SceneManager.GetActiveScene();
                Time.timeScale = 1;
                StartCoroutine(CarregarCena(cena[0]));
            }
        }
        else if (textoUI[index].text != texto[index]) //Aqui é onde verifica se ainda esta escrevendo o texto caso esteja, vai parar de escrever para completar o texto 
        {
            StopAllCoroutines();
            textoUI[index].text = texto[index];
            tempoPular = Time.time + 1f;
            audioSource.Stop();
        }
    }

    void AtivarImagem() //Vai ativar imagem por imagem dependendo de qual texto esta escrevendo
    {
        if(index == 0)
        {
            img[0].SetActive(true);
        }else if(index == 2)
        {
            img[1].SetActive(true);
        }
        else if (index == 4)
        {
            img[2].SetActive(true);
        }
        else if (index == 5)
        {
            img[3].SetActive(true);
        }
    }

    void ProximoTexto() // Aqui ele passa para o proximo texto
    {
        index++;
        textoUI[index - 1].gameObject.SetActive(false);
        textoUI[index].gameObject.SetActive(true);
        textoUI[index].text = "";
    }

    public void BotaoCarregarCena(int cena)
    {
        if (cena == 1)
        {
            StartCoroutine(CarregarCena(this.cena[0]));
        }
        else if(cena == 2)
        {
            StartCoroutine(CarregarCena(this.cena[1]));
        }
    }

    IEnumerator CarregarCena(string cena)
    {
        if(cena == "" | cena == null)
        {
            yield return null;
        }

        AsyncOperation loadscene = SceneManager.LoadSceneAsync(cena);

        while (!loadscene.isDone)
        {
            yield return null;
        }
        /*
        AsyncOperation unloadScene = SceneManager.UnloadSceneAsync(cenaAtual);

        while (!unloadScene.isDone)
        {
            yield return null;
        }
        */
    }

    void ReproduzirAudio() //Reproduz o audio
    {
        audioSource.Stop();
        audioSource.clip = audioClip[0];
        if(index == 0)
        {
            audioSource.time = 3f;
        }
        else if (index == 1)
        {
            audioSource.time = 10.215f;
        }
        else if (index == 2)
        {
            audioSource.time = 0.9f;
        }
        else if (index == 3)
        {
            audioSource.time = 4.5f;
        }
        else if (index == 4)
        {
            audioSource.time = 4.5f;
        }
        else if (index == 5)
        {
            audioSource.time = 16;
        }
        audioSource.Play();
    }
}
