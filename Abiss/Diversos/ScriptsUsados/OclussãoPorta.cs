using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OclussãoPorta : MonoBehaviour
{
   // public Color colisorAtivo;
   // public Collider2D porta;
    //public GameObject luna;
    private Renderer coror;
    //SpriteRenderer coror;
    GameObject player;
    
    Color nocolor = new Color(1f, 1f, 1f, 0.2f);
    // Start is called before the first frame update
    void Start()
    {
        coror = GetComponent<Renderer>();
        Transparente();
        // player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.transform.position == porta.gameObject.transform.position)
       // if (porta.gameObject.CompareTag("Player"))
       // {
        //    coror.material.color = basecolor;
        //    Debug.Log("entrada");
       // }
       //else
      //  {
        //    coror.material.color = nocolor;
        //}
        
    //    OnTriggerEnter2D(porta);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag( "Player"))
       {
            Opaco();
        }
        else
        {
            Transparente();
        }
   }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transparente();
        }
    }
    void Opaco()
    {
        Color basecolor = new Color(1f, 1f, 1f, 0.88f);
        //coror.material.color =  basecolor;
    }
    void Transparente()
    {
        //coror.material.color = nocolor;
    }
    //private void OnTriggerExit(Collider2D other)
 //   {
  //      if (other.CompareTag("Player"))
    //    {
   //         colisorAtivo.a = 0.3F;
   //     }
  //  }
}
