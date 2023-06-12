using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarItem : MonoBehaviour {
    public Item item; 
    public int quantidade;
    //public Coletado coletados;
    //public int id;
    Vector3 posicao;
    
    /*public void Awake(){
        if(coletados.coletado.Count >= id){
            if(coletados.coletado.Find(x => x.id == id).id == id){
                Destroy(gameObject);
            }
        }
    }*/
    public void Update(){
        posicao = Camera.main.WorldToScreenPoint(transform.position);
    }

    /*
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            coletados.coletar(gameObject.GetComponent<ColetarItem>());
        }
    } 
    */
    /*void OnGUI(){
        Rect rect = new Rect(new Vector2(posicao.x + ((Screen.width * -7) / 100), Screen.height - posicao.y + ((Screen.height * -9) / 100)), new Vector2(500,450));
        GUI.skin.label.fontSize = ((Screen.width + Screen.height) * 2) / 130;
        GUI.Label(rect, item.nome);
    }*/
}