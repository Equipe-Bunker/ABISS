using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhoPlayer : MonoBehaviour
{
    bool passouAqui;
    public bool emPerseguicao;
    InimigoPerseguidor inimigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (emPerseguicao == true && passouAqui == true)
        {
            inimigo = FindObjectOfType<InimigoPerseguidor>();
            StartCoroutine(DesativaBool());

        }
    }
    public void Perseguicao()
    {
        emPerseguicao = !emPerseguicao;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            passouAqui = true;
        }
    }

    IEnumerator DesativaBool()
    {
       
        inimigo.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(5f);
        passouAqui = false;
    }

    /*private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            passouAqui = false;
            //emPerseguicao = false;
        }
    }*/

}
