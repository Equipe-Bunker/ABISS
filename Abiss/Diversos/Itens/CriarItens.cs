using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewItem", menuName = "Itens/Criar Item")]

public class CriarItens : ScriptableObject{
    public enum tipos { Item, Coletaveis, Documento }
    public tipos tipo;
    public string nome;
    public int level;
    [TextArea(3, 5)]
    public string descricao;
    public GameObject prefab;
    public Sprite imagem;

}