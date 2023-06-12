using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadGame : MonoBehaviour
{
    [Tooltip("Qual tecla que precisa apertar para executar a ação, caso não selecione sera definido por padrão a tecla \"E\"")][SerializeField] KeyCode tecla;
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

    void Update()
    {
        if (colisaoPlayer && Input.GetKeyUp(tecla))
        {
            Load();
        }
    }

    void Load()
    {
        if (File.Exists(saveManager.arquivoSave))
        {
            string jsonS = File.ReadAllText(saveManager.arquivoSave);
            JsonUtility.FromJsonOverwrite(jsonS, saveManager.savePlayer);

            saveManager.ativaDocumento = GameObject.FindObjectOfType<AtivaDocumento>();
            saveManager.player.GetComponent<Player>().SetVida(saveManager.savePlayer.vida);
            saveManager.player.transform.eulerAngles = new Vector3(0, 0, 0);
            saveManager.player.transform.position = saveManager.savePlayer.posicaoSave;
            saveManager.player.GetComponent<Player>().InventoryClear();
            for (int a = 0; a < saveManager.savePlayer.itens.Length; a++)
            {
                saveManager.player.GetComponent<Player>().invPlayer.AdicionarItem(saveManager.savePlayer.itens[a], saveManager.savePlayer.quantidade[a]);
            }
            saveManager.ativaDocumento.load(saveManager.savePlayer.documentos);
            Debug.Log("Carregado");
        }
        else
        {
            Debug.Log("Arquivo de load, nao existe");
        }

        // ------------------------- Carregar dados do mapa -------------------------//
        if (File.Exists(saveManager.arquivoSaveMap))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(saveManager.arquivoSaveMap, FileMode.Open);

            saveManager.saveMap = (saveInfoMap)bf.Deserialize(fs);
            fs.Close();

            saveManager.puzzleArmario.SetSave(saveManager.saveMap.armarioPuzzle);
            saveManager.puzzleQuadro.SetSave(saveManager.saveMap.quadroPuzzle);

            //Area do for
            for(int a = 0; a < saveManager.saveMap.porta.Length; a++)
            {
                saveManager.portas[a].SetAbriu(saveManager.saveMap.porta[a]);
            }
            for(int a = 0; a < saveManager.saveMap.conversas.Length; a++)
            {
                saveManager.dialogo[a].SetCabou(saveManager.saveMap.conversas[a]);
            }
        }
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
                text.text = "Presione \"" + tecla + "\" para carregar";
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
