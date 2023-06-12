using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class SumirPiso : MonoBehaviour
{
    public GameObject  chao1;
    public GameObject chao2;
    public bool quebrar;
    // Start is called before the first frame update
    void Start()
    {
        quebrar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (quebrar == true)
        {
            Object.Destroy(chao1);
            Object.Destroy(chao2);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           quebrar = true;
        }
    }
}
