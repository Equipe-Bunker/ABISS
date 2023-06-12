using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

public class SaveManager : MonoBehaviour
{
    [HideInInspector] public string arquivoSave;
    [HideInInspector] public string arquivoSaveMap;
    [HideInInspector] public GameObject player;
    [HideInInspector] public saveInfoPlayer savePlayer;
    [HideInInspector] public saveInfoMap saveMap = new saveInfoMap();

    [Tooltip("Aqui voce coloca todos os dialogos com script ControleDialogo")] public ControleDialogo[] dialogo;
    [Tooltip("Aqui voce coloca todas as portas da cena")] public Porta[] portas;
    [HideInInspector] public GerenciaPuzzle puzzleArmario;
    [HideInInspector] public SalaChefe puzzleQuadro;
    [HideInInspector] public AtivaDocumento ativaDocumento;

    void Awake()
    {
        savePlayer = gameObject.AddComponent<saveInfoPlayer>();
        //Definir local do save no seu computador
        arquivoSave = Path.Combine(Application.dataPath, "savegame/Player.json");
        arquivoSaveMap = Path.Combine(Application.dataPath, "savegame/Save.dat");

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        if(portas == null || portas.Length == 0)
        {
            portas = GameObject.FindObjectsOfType<Porta>();
        }
        if(dialogo == null || dialogo.Length == 0)
        {
            dialogo = GameObject.FindObjectsOfType<ControleDialogo>();
        }
        puzzleArmario = GameObject.FindObjectOfType<GerenciaPuzzle>();
        puzzleQuadro = GameObject.FindObjectOfType<SalaChefe>();
    }

}
 
public class saveInfoPlayer : MonoBehaviour{
    public Vector3 posicaoSave;
    public int vida;
    public Item[] itens;
    public int[] quantidade;
    public bool[] documentos;
}

[System.Serializable]
public class saveInfoMap
{
    public bool[] porta;
    public bool[] conversado;
    public bool[] conversas;
    public bool armarioPuzzle;
    public bool quadroPuzzle;
}