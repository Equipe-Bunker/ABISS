using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "item", menuName = "Inventario/Criar Novo Item")]
public class Item : ScriptableObject
{
    public enum tipo { Iluminacoes, Armas, Item, Bateria, Puzzle, Pregos, Circuito, Outros, SOS, Injecao, Cura, Documento }

    public Sprite imagem;
    public tipo tipos;
    public string nome;
    public int level;
    [TextArea(1,5)]
    public string descricao;
    public GameObject prefab;
}
