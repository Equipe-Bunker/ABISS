using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "inventario", menuName = "Inventario/CriarInventario")]
public class ScriptInventory : ScriptableObject
{
    public List<Inventario> inventario = new List<Inventario>();

    [Tooltip("Adiciona Item no inventario")]
    public void AdicionarItem(Item _item, int _quantidade){
        if (_item != null)
        {
            if (inventario.Exists(x => x.item.Equals(_item)))
            {
                inventario.Find(x => x.item.Equals(_item)).quantidade += _quantidade;
            }
            else
            {
                inventario.Add(new Inventario(_item, _quantidade));
            }
        } else { Debug.LogError("Item \"null\" adicionado: " + _item); }
    }

    [Tooltip("Remove uma Quantidade do Item do inventario")]
    public void RemoverItem(Item _item, int _quantidade){
        if(inventario.Count > 0 && inventario.Exists(x => x.item.Equals(_item)))
        {
            inventario.Find(x => x.item.Equals(_item)).quantidade -= _quantidade;
            if(inventario.Find(x => x.item.Equals(_item)).quantidade < 0) { inventario.Find(x => x.item.Equals(_item)).quantidade = 0; }
        }
        else { Debug.LogError("Item não encontrado"); }
    }
    public void RemoverItem(Item _item, int _quantidade, bool deletarItem)
    {
        if (inventario.Count > 0 && inventario.Exists(x => x.item.Equals(_item)))
        {
            inventario.Find(x => x.item.Equals(_item)).quantidade -= _quantidade;
            if (inventario.Find(x => x.item.Equals(_item)).quantidade <= 0 && deletarItem) { RemoverItem(_item); }
        }
        else { Debug.LogError("Item não encontrado"); }
    }
    [Tooltip("Remove Item do inventario")]
    public void RemoverItem(Item _item){
        if(inventario.Count > 0 && inventario.Exists(x => x.item.Equals(_item)))
        {
            int a = inventario.FindIndex(x => x.item == _item);
            inventario.RemoveAt(a);
        }
        else { Debug.LogError("Item não encontrado"); }
    }


    string itemVerificado;
    [Tooltip("Procura pelo nome do item no inventario | Caso não ache nada retorna nulo")]
    public Item ProcurarItem(string nome_do_item){
        if(inventario.Count > 0 && inventario.Exists(x => x.item.nome.Equals(nome_do_item)))
        {
            return inventario.Find(x => x.item.nome.Equals(nome_do_item)).item;
        }
        else
        {
            if(!itemVerificado.Equals(nome_do_item))
            {
                itemVerificado = nome_do_item;
                Debug.LogWarning("Item não encontrado: " + nome_do_item);
            }
            return null;
        }
    }

    [Tooltip("Procura pela quantidade do item no inventario | Caso não ache nada retorna -1")]
    public int ProcurarQuantidade(string nome_do_item){
        if(inventario.Count > 0 && inventario.Exists(x => x.item.nome.Equals(nome_do_item)))
        {
            return inventario.Find(x => x.item.nome.Equals(nome_do_item)).quantidade;
        }else{
            Debug.Log("Item não encontrado: " + nome_do_item);
            return -1;
        }
    }
    
    [Tooltip("Procura todos os item do tipo que deseja | caso não ache retorna um array vazio")]
    public Item[] ProcurarTipo(Item.tipo tipo)
    {
        List<Inventario> list = (inventario.FindAll(x => x.item.tipos.Equals(tipo)));
        if (list.Count > 0)
        {
            return list.Select(x => x.item).ToArray();
        }
        else
        {
            Debug.Log("Tipo de item não encontrado: " + tipo);
            return new Item[0];
        }
    }
}

[System.Serializable]
public class Inventario{
    public Item item;
    public int quantidade;

    public Inventario(Item _item, int _quantidade){
        item = _item;
        quantidade = _quantidade;
    }
}
    