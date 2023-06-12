using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAbre : MonoBehaviour
{
    public bool show;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            GUI.skin.label.fontSize = 11;
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 20, 200, 30), "Não faz sentido eu voltar para lá");

        }
    }
}
