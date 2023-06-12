using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControleBotao : MonoBehaviour
{

    public GameObject ativaCorreto, ativaFuncao;

    public GameObject GrupoBotoes;
    public GameObject[] Botoes;

    PuzzleControl pz;

    [SerializeField]
    int totalBotoes = 0;
    
    public int figurasCorretas = 0;

    // Start is called before the first frame update
    void Start()
    {

        pz = FindObjectOfType<PuzzleControl>();
        totalBotoes = GrupoBotoes.transform.childCount;

        Botoes = new GameObject[totalBotoes];

        for(int i = 0; i < Botoes.Length; i++)
        {
            Botoes[i] = GrupoBotoes.transform.GetChild(i).gameObject;
        }
    }

    public void Correto()
    {
        figurasCorretas += 1;
        Debug.Log("Circuito Correto");

        if (figurasCorretas == totalBotoes)
        {
            Debug.Log("Puzzle Resolvido!!!");
            ativaCorreto.SetActive(true);
            ativaFuncao.SetActive(true);
            pz.desativaBt = true;
        }
    }


    public void Errado()
    {
        figurasCorretas -= 1;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
