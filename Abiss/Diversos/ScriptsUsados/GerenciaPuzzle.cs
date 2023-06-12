using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciaPuzzle : MonoBehaviour
{
    public GameObject armarioSenha;
    bool itemColetado; 
    [SerializeField] Animator animArmario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FechaArmario()
    {
        animArmario.SetBool("Abrir", true);
        armarioSenha.SetActive(false);
        itemColetado = true;
    }

    public bool GetSave()
    {
        return itemColetado;
    }

    public void SetSave(bool s)
    {
        if (s)
        {
            FechaArmario();
        }
    }
}
