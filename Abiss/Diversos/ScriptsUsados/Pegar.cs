using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegar : MonoBehaviour
{
    public bool show;
    public bool msm;
    public bool tmp;
    // Start is called before the first frame update
    void Start()
    {
        msm = false;  
    }

    // Update is called once per frame
    void Update()
    {
     if(show == true && Input.GetKeyDown(KeyCode.E))
        {
            show = false;
            msm = true;
            StartCoroutine("Fim");
        }  
            
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            show = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            show = false;
        }
    }
    void OnGUI()
    {
        if (show == true)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 16;
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 20, 200, 30), "Interagir");

        }
        if (msm == true)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 16;
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 20, 200, 30), "Imagino o que isso faz");

        }
    }
    IEnumerator Fim()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
