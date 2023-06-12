using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    public bool seCurar= false;
    Player player;
    public int valorCura, vidaPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        vidaPlayer = player.vida;
    }

    void Update()
    {
        /*if(seCurar == true)
        {
            ExecutaCura();
        }*/
    }


    public void ExecutaCura()
    {
        vidaPlayer = +valorCura;
        Debug.Log("Se Curou");
    }
}
