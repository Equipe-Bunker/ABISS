using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoContinuo : MonoBehaviour
{
    [SerializeField] int dano;
    Player player;
    int i;
    bool tocou;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tocou == true && player.luzAtiva == false)
        {
            i++;
            if (i == 1)
            {
                
                StartCoroutine(DanoInfinito());
                
            }
            
        }
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tocou = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            tocou = false;
            i = 0;
            //player.luzAtiva = false;
        }
        
    }

    


    IEnumerator DanoInfinito()
    {
        yield return new WaitForSeconds(3f);
        player.darDano(dano);
        i = 0;
        Debug.Log("Tomou Dano");

    }

    

}
