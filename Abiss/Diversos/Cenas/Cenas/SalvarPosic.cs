using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//este script deve estar no seuu Player e deve ter o nome "SalvaPosic"


public class SalvarPosic : MonoBehaviour
{
    string nomeCenaAtual;

    // Start is called before the first frame update
    void Awake()
    {
        nomeCenaAtual = SceneManager.GetActiveScene().name;
    }
    private void Start()
    {
        if(PlayerPrefs.HasKey(nomeCenaAtual+ "X") && PlayerPrefs.HasKey(nomeCenaAtual + "Y") && PlayerPrefs.HasKey(nomeCenaAtual + "Z"))
        {
            transform.position = new Vector3 (PlayerPrefs.GetFloat(nomeCenaAtual + "X"), PlayerPrefs.GetFloat(nomeCenaAtual + "Y"), PlayerPrefs.GetFloat(nomeCenaAtual + "Z"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SalvarLocalizacao()
    {
        PlayerPrefs.SetFloat(nomeCenaAtual + "X", transform.position.x);
        PlayerPrefs.SetFloat(nomeCenaAtual + "X", transform.position.y);
        PlayerPrefs.SetFloat(nomeCenaAtual + "X", transform.position.z);
    }
}
