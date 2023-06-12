using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buscar_Itens_no_Player : MonoBehaviour
{
    Player player;
    Item itens;
    
    void Start()
    {
        //pegar o script do player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        bla();
    }

    void bla() {
        //verifica se ele tem o item, caso tenha sera retornado o item
        //onde é possivel verificar tudo sobre o item no inventario do player
        itens =  player.invPlayer.ProcurarItem("Lanterna");

        //verifica a quantidade do item desejado
        int quant = player.invPlayer.ProcurarQuantidade(itens.nome);
        //OBS: voce vai usar o item que colocou na variavel acima para buscar a quantidade deste item.
        int quant2 = player.invPlayer.ProcurarQuantidade("Lanterna");
        //OBS: Entre as aspas onde esta escrito lanterna serve para escrever o nome do item.

        Debug.Log(itens);
        Debug.Log(quant);
        Debug.Log(quant2);
    }
}
