using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms;
using System;

public static class SalvarInformacoes
{
    static string nome, texto;
    static float tempoInicio;
    static bool comecou, salvar;
    static string tempo;
    

    //Local que sera salvo
    static string filePath;
    static string local;
    public static void EscreverLinha(string linha)
    {
        if (salvar)
        {
            if (!comecou)
            {
                tempoInicio = Time.time;
                comecou = true;
                filePath = Path.Combine(Application.dataPath + "/Informacoes/" + nome + ".txt");
                local = Path.Combine(Application.dataPath + "/Informacoes");
                EscreverLinha(linha);
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time - tempoInicio);
                tempo = timeSpan.ToString(@"mm\:ss");
                texto += "\n[" + tempo + "] -> " + linha;
                Debug.Log(linha);
                if (!Directory.Exists(local))
                {
                    Directory.CreateDirectory(local);
                }
                File.WriteAllText(filePath, texto);
            }
        }
    }
    public static bool EscreverNome(string name)
    {
        if (name != null && name.Length > 3) {
            comecou = false;
            salvar = true;
            nome = name;
            return true;
        }
        else
        {
            return false;
        }
    }
}
