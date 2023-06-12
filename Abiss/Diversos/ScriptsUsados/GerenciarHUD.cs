using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciarHUD : MonoBehaviour
{
    [SerializeField] Navegar inventario;
    [SerializeField] Pausa menu;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && !inventario.VerificarAberto() && !menu.VerificarAberto() && !player.parado)
        {
            inventario.AbrirHudInventario();
            player.ChamaBarraVida();
            player.SetParado(true);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventario.FecharHudInventario();
            player.SetParado(false);
        }

        if (Input.GetKeyUp(KeyCode.Escape) && inventario.VerificarAberto())
        {
            inventario.FecharHudInventario();
            player.SetParado(false);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && !menu.VerificarAberto()) 
        {
            menu.AbrirMenuPausa();
            GerenciarTempo.Pause();
        }
        else if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            menu.FecharMenuPausa();
            if (!menu.VerificarAberto())
            {
                GerenciarTempo.Despausar();
            }
        }
    }
}
