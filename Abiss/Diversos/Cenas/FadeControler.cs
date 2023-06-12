using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FadeControler : MonoBehaviour
{
    public GameObject fade;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        fade.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        anim.SetBool("ativa", false);

    }

    public void FadeOut()
    {
        
        anim.SetBool("ativa",true);
        
    }

    
}
