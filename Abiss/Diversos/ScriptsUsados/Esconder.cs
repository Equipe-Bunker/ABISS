using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconder : MonoBehaviour
{
    public bool tocando;
    public bool escon;
    public GameObject interagir;
    

    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && tocando == true) 
        {
            player.AtivarEsconder(); //por algum motivo isso nãoo ta fuincionndo

            escon = true;
            Debug.Log("passou");
        }
        if (Input.GetKeyDown(KeyCode.E) && escon == true && tocando == true)
        {
            player.DesativarEsconder();
            escon = false;
        }

    }

   /* public void Escondido()
    {
        
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = true;
            interagir.SetActive(true); 
            

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tocando = false;
            interagir.SetActive(false);
            
        }
    }

}
