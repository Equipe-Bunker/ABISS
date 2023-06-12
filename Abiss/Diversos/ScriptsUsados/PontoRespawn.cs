using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoRespawn : MonoBehaviour
{
    public Transform destino;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (player)
        {
            player.transform.position = destino.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
