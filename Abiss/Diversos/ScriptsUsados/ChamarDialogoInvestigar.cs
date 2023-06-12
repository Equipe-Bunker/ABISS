using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class ChamarDialogoInvestigar : MonoBehaviour
{
    //public string nomeItem;
    Player player;
    int n, i;
    public GameObject dialogo, interagir;

    bool podeEntregar;
    
    public UnityEvent evento;
    bool podeInteragir;
    
    

    //public PlayableDirector CenaFlashBack, cenainjecao;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        

        if (podeInteragir == true)
        {
            if(Input.GetKeyUp(KeyCode.E) && i == 0)
            {
                AtivaDialogo();
                i++;
            }

            
        }
        
        
        if(podeInteragir == false)
        {
            
        }
        


    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            podeInteragir = true;
            interagir.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        interagir.SetActive(false);
        if (col.CompareTag("Player"))
        {
            podeInteragir = false;
            i = 0;
        }  
    }

    public void AtivaDialogo()
    {
        
        dialogo.SetActive(true);
        evento.Invoke();
        player.SetParado(true);

    }

    public void DesativaDialogo()
    {
        dialogo.SetActive(false);
    }

    public void FimDialogo()
    {
        player.SetParado(false);
        //i = 0;

    }

    public void EntregaKit()
    {
        n = player.inventario.inventario.FindIndex(x => x.item.nome == "Kit SOS");
        player.inventario.inventario.RemoveAt(n);
    }
    

    

    /*public void EntregaInjeção()
    {
        n = player.inventario.inventario.FindIndex(x => x.item.nome == "Injeção");
        player.inventario.inventario.RemoveAt(n);
    }*/

    
}
