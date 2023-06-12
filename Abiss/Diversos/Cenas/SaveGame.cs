//using Mono.Cecil.Cil;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{
    [Tooltip("Qual tecla que precisa apertar para executar a ação, caso não selecione sera definido por padrão a tecla \"E\"")] [SerializeField] KeyCode tecla;
    [Tooltip("Ponto que sera salvo o spawn quando der load game, caso não coloque sera definido como local a posicao desse objeto")][SerializeField] Transform spawn;
    [Tooltip("Texto pedindo para apertar alguma tecla")][SerializeField] GameObject UI;
    [Tooltip("O GameObject que esta com o SaveManager")][SerializeField] SaveManager saveManager;
    TextMeshProUGUI text;
    bool colisaoPlayer;
        
    private void Start()
    {
        saveManager = gameObject.AddComponent<SaveManager>();
        //Verificando se os parametros estao vazios caso esteja ira definir alguns atributos automaticamente
        if (tecla == KeyCode.None)
        {
            tecla = KeyCode.E;
        }
        if (spawn == null)
        {
            spawn = transform;
        }
       
    }

    private void Update()
    {
        if (colisaoPlayer && Input.GetKeyUp(tecla))
        {
            Save();
        }
    }

    public void Save()
    {
        // ------------------------- Salvar dados do player -------------------------//
        //Aqui usando o JSON para salvar para isso precisa do System e do System.IO
        //Setar dados a ser salvo do player || Salva a posição, vida e inventario do Player

        saveManager.ativaDocumento = GameObject.FindObjectOfType<AtivaDocumento>();
        saveManager.savePlayer.posicaoSave = spawn.position;
        saveManager.savePlayer.vida = saveManager.player.GetComponent<Player>().GetVida();
        saveManager.savePlayer.itens = saveManager.player.GetComponent<Player>().TodosItens();

        saveManager.savePlayer.documentos = new bool[saveManager.ativaDocumento.save().Length];
        saveManager.savePlayer.quantidade = new int[saveManager.player.GetComponent<Player>().invPlayer.inventario.Count];

        for (int a = 0; a < saveManager.player.GetComponent<Player>().invPlayer.inventario.Count; a++)
        {
            saveManager.savePlayer.quantidade[a] = saveManager.player.GetComponent<Player>().invPlayer.ProcurarQuantidade(saveManager.savePlayer.itens[a].nome);
        }
        saveManager.savePlayer.documentos = saveManager.ativaDocumento.save();


        //Criar arquivo de save
        string json = JsonUtility.ToJson(saveManager.savePlayer);
        File.WriteAllText(saveManager.arquivoSave, json);

        
        // ------------------------- Salvar dados do mapa -------------------------//
        //Aqui usando o Binary para salvar para isso precisa do System do System.IO e do System.Runtime.Serialization.Formatters.Binary
        //Aqui salva as portas e conversas do mapa
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(saveManager.arquivoSaveMap, FileMode.Create);

        saveManager.saveMap.armarioPuzzle = saveManager.puzzleArmario.GetSave();
        saveManager.saveMap.quadroPuzzle = saveManager.puzzleQuadro.GetSave();

        //Area do for
        saveManager.saveMap.porta = new bool[saveManager.portas.Length];
        saveManager.saveMap.conversas = new bool[saveManager.dialogo.Length];

        for(int a = 0; a < saveManager.portas.Length; a++)
        {
            saveManager.saveMap.porta[a] = saveManager.portas[a].GetAbriu();
        }
        for (int a = 0; a < saveManager.dialogo.Length; a++)
        {
            saveManager.saveMap.conversas[a] = saveManager.dialogo[a].GetCabou();
        }


        bf.Serialize(fs, saveManager.saveMap);
        fs.Close();

        text.text = "Jogo Salvo";
        Debug.Log("Salvo");
    }

    //------------- Detectar Colisão

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            colisaoPlayer = true;
            if (UI != null)
            {
                UI.SetActive(true);
                text = UI.GetComponentInChildren<TextMeshProUGUI>();
                text.text = "Presione \"" + tecla + "\" para salvar";
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            colisaoPlayer = false;
            if (UI != null)
            {
                UI.SetActive(false);
            }
        }
    }
}
