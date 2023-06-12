using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Itens/Lista Coletados", fileName = "ItensColetados")]
public class Coletado : ScriptableObject
{   
    /*
    public List<Coletados> coletado = new List<Coletados>();
    
    public void coletar(ColetarItem item){
        bool achou = false;
        for(int i = 0; i < coletado.Count; i++){
            if(coletado[i].id == item.id){
                achou = true;
                break;
            }
        }
        if(!achou){
            coletado.Add(new Coletados(item.id));
        }
    }
}

[System.Serializable]
public class Coletados{
    public int id;
    public Coletados(int _id){
        id = _id;
    }
    */
}
