using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporteSimples : MonoBehaviour
{
    public float tempo;
    public Transform destination;
    [SerializeField] float ajuste_Y;
    GameObject player;
    public GameObject abrirCanvas;

    FadeControler fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeControler>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().GetAgachado() && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = destination.position;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
             abrirCanvas.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            abrirCanvas.SetActive(false);
        }

    }




}
