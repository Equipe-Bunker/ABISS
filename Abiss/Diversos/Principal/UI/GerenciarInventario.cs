using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciarInventario : MonoBehaviour
{
    AudiosPequenos audiosPequenos;
    [SerializeField]DescItens descItens;
    ScriptInventory invPlayer;
    GameObject[] slots = new GameObject[0];
    int slotsOn;
    void Awake()
    {
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
        //inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().inventario;
        slots = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++){
            slots[i] = gameObject.transform.GetChild(i).gameObject;
            
        }
        AtualizarInv();
    }

    public void AtualizarInv(){   
        foreach(GameObject obj in slots){
            obj.SetActive(false);
        }
        slotsOn = invPlayer.inventario.Count;
        for(int i = 0; i < slotsOn; i++){
            
            slots[i].SetActive(true);
            slots[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = invPlayer.inventario[i].item.nome;
            if(invPlayer.inventario[i].item.tipos == Item.tipo.Item){
                slots[i].transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Level: " + invPlayer.inventario[i].item.level;
            }
            else{
                slots[i].transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Quantidade: " + invPlayer.inventario[i].quantidade;
            }
            
        }
        /*for(int i = 0; i < inventario.inventario.Count; i++){
            if(inventario.inventario.Count >= numeroInv){
                Text text = transform.GetChild(0).GetComponent<Text>();
                Text level = transform.GetChild(1).GetComponent<Text>();
                text.text = inventario.inventario[i].item.nome;
                level.text = "Level: " + inventario.inventario[i].item.level;
                on = true;
                break;
            }
        }
        if(!on){
            gameObject.SetActive(false);
        }*/
    }

    public void botaoDescricao(Button i){
        //descItens.ItemDescricao(invPlayer.inventario.Find(x => x.item.nome.Contains(i.transform.GetChild(0).GetComponent<Text>().text)));
    }
}
