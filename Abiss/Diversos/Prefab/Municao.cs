using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    public float velocidade;
    public float tempo;
    void Start()
    {
       gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * velocidade;
       tempo += Time.time;
    }
    void Update(){
        if(tempo < Time.time){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
        }
            
    }

    
}
