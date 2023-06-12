
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarCena : MonoBehaviour
{
    [SerializeField] string cena;
    bool estaNaPorta;
    GameObject player;
    Vector3 posicaoTela;
    Rect rect;
    bool cartao;

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            player = col.gameObject;
            estaNaPorta = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            player = null;
            estaNaPorta = false;
        }
    }
    void Update(){
        posicaoTela = Camera.main.WorldToScreenPoint(transform.position);
        if(Input.GetKeyDown(KeyCode.E) && estaNaPorta && player.GetComponent<Player>().inventario.inventario.Exists(x => x.item.nome.Equals("Cartao de Acesso"))){
            StartCoroutine(cenario());
        }else if(Input.GetKeyDown(KeyCode.E) && estaNaPorta && !player.GetComponent<Player>().inventario.inventario.Exists(x => x.item.nome.Equals("Cartao de Acesso"))){
            cartao = true;
            StartCoroutine(Cartao());
        }
    }
    IEnumerator cenario(){

        Scene Unload = SceneManager.GetSceneAt(1);
        AsyncOperation carregamentoAsync = SceneManager.LoadSceneAsync(cena, LoadSceneMode.Additive);
        if(!carregamentoAsync.isDone){
            yield return null;
        }
        SceneManager.UnloadSceneAsync(Unload);
    }

    IEnumerator Cartao(){
        yield return new WaitForSeconds(1);
        cartao = false;
    }

    void OnGUI(){
        if(cartao){
            rect = new Rect(new Vector2(posicaoTela.x + ((Screen.width * -3) / 100), Screen.height - posicaoTela.y + ((Screen.height * -15) / 100)), new Vector2(500,450));
            GUI.skin.label.fontSize = ((Screen.width + Screen.height) * 2) / 170;
            GUI.Label(rect, "Precisa do Cartão de Acesso");
        }else{
            GUI.Label(rect, "");
        }
    }
}
