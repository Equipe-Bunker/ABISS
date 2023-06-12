using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;

public class EsterEgg : MonoBehaviour
{
    [Tooltip("Aqui vao as respostas que sera dada, lembrando que começa do 1")][SerializeField][TextArea(1,3)] string[] respostas;
    [SerializeField] GameObject painelTexto;
    [Tooltip("Onde vai escrever o texto")][SerializeField] TextMeshProUGUI texto;
    [Tooltip("Quais são as perguntas, lembrando que tem que ser proporcional as respostas")][SerializeField] GameObject painelBotoes;
    [Tooltip("Todos os botoes")][SerializeField] GameObject[] botoes;
    [SerializeField] GameObject textoUI;
    [SerializeField] GameObject luz;
    [SerializeField] float tempoCarregamento; // tempo em segundos para simular o carregamento
    [SerializeField] AnimationCurve curvaDeCarregamento; // curva de animação para controlar a velocidade do preenchimento

    SalaChefe chefe;
    bool triggerIO, apertou;
    Player player;


    IEnumerator SimularCarregamento(int escolha)
    {
        float timer = 0f;

        while (timer < tempoCarregamento)
        {
            timer += Time.deltaTime;
            float progress = timer / tempoCarregamento;
            float curveProgress = curvaDeCarregamento.Evaluate(progress); // usa a curva de animação para ajustar a velocidade do preenchimento
            SetProgress(escolha, curveProgress); // atualiza a barra de progresso
            yield return null;
        }
        SetProgress(escolha, 1.0f); // garante que a barra de progresso chegue a 100%
    }

    public void SetProgress(int escolha, float progress)
    {
        botoes[escolha].GetComponent<UnityEngine.UI.Image>().fillAmount = progress;
        if(progress == 1)
        {
            AtivarTexto(escolha);
        }
    }

    private void Start()
    {
        chefe = GameObject.FindObjectOfType<SalaChefe>();
    }

    void Update()
    {
        if (chefe.GetSave())
        {
            if (!luz.activeSelf)
            {
                luz.SetActive(true);
            }
            if (triggerIO && Input.GetKeyDown(KeyCode.E))
            {
                if (!painelBotoes.activeSelf && !painelTexto.activeSelf)
                {
                    apertou = false;
                    if (player != null)
                    {
                        player.SetParado(true);
                    }
                    painelTexto.SetActive(false);
                    painelBotoes.SetActive(true);
                    AtivarBotoes();
                    textoUI.SetActive(false);
                }
                else
                {
                    if (player != null)
                    {
                        player.SetParado(false);
                    }
                    painelBotoes.SetActive(false);
                    painelTexto.SetActive(false);
                    textoUI.SetActive(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (player != null)
                {
                    player.SetParado(false);
                }
                painelBotoes.SetActive(false);
                painelTexto.SetActive(false);
                textoUI.SetActive(true);
            }
        }
    }

    public void BOTAOAQUI(int qualTexto)
    {
        if (!apertou)
        {
            apertou = true;
            switch (qualTexto)
            {
                case 0:
                    DesativarBotoes(0);
                    StartCoroutine(SimularCarregamento(0));
                    break;
                case 1:
                    DesativarBotoes(1);
                    StartCoroutine(SimularCarregamento(1));
                    break;
                case 2:
                    DesativarBotoes(2);
                    StartCoroutine(SimularCarregamento(2));
                    break;
                case 3:
                    DesativarBotoes(3);
                    StartCoroutine(SimularCarregamento(3));
                    break;
            }
        }
    }

    void DesativarBotoes(int botao)
    {
        for (int a = 0; a < botoes.Length; a++)
        {
            if (a != botao)
            {
                botoes[a].SetActive(false); 
            }
        }
    }

    void AtivarBotoes()
    {
        for (int a = 0; a < botoes.Length; a++)
        {
            botoes[a].SetActive(true);
            botoes[a].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
        }
    }

    void AtivarTexto(int escolha)
    {
        painelBotoes.SetActive(false);
        painelTexto.SetActive(true);
        texto.text = respostas[escolha];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && chefe.GetSave())
        {
            triggerIO = true;
            player = col.GetComponent<Player>();
            textoUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            painelBotoes.SetActive(false);
            painelTexto.SetActive(false);
            textoUI.SetActive(false);
            triggerIO = false;
            player = null;
        }
    }
}
