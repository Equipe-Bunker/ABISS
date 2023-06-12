using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DetecPlayer : MonoBehaviour
{
    bool tocando, ativou;
    public PlayableDirector playableDirector;
    int n = 0;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    


    // Update is called once per frame
    void Update()
    {
        if (tocando == true && n == 1 && ativou == false)
        {
            AtivaAparição();
        }
    }

    public void AtivaAparição()
    {
        ativou = true;
       
        playableDirector.Play();

        SalvarInformacoes.EscreverLinha("Ativou a aparição, agora se ele viu é outros quinhentos");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) 
        {
            n++;
            tocando = true;
        }
    }
}
