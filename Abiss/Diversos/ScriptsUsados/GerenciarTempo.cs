using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GerenciarTempo
{
    public static void Pause()
    {
        Debug.Log("timeScale setado para 0");
        Time.timeScale = 0;
    }

    public static void Despausar()
    {
        Debug.Log("timeScale setado para 1");
        Time.timeScale = 1;
    }

    public static void EscalaTempo(int scale) 
    {
        Debug.Log("timeScale setado para " + scale);
        Time.timeScale = scale;
    }

    public static bool VerificarPause()
    {
        if(Time.timeScale == 0)
        {
            return true;
        }
        else { return false; }
    }
}
