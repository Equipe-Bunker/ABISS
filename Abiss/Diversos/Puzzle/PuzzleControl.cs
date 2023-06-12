using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleControl : MonoBehaviour
{
    float[] rotations = { 0, 60, 120, 240, 360 };
    public Transform exagonos;
    Button corBotao;
    

    public float rotacaoCorreta;
    int rotacaoInt;


    bool isPlaced = false;

    public bool desativaBt = false;

    PuzzleControleBotao pcb;
    float rotacao;
    
    /*public void DesativaBotoes()
    {
        exagonos.gameObject.GetComponent<Button>().interactable = false;
    }*/


    private void Awake()
    {
        
        pcb = GameObject.Find("ManagerPuzzle").GetComponent<PuzzleControleBotao>();
    }

    public void Interagir()
    {
        exagonos.transform.Rotate(new Vector3(0, 0, 60));

        rotacao = exagonos.eulerAngles.z;
        rotacaoInt = Mathf.RoundToInt(rotacao);
        //Debug.Log(rotacaoInt);

        if (rotacaoCorreta == rotacaoInt && isPlaced == false)
        {
            Debug.Log("Passou aqui2");
            isPlaced = true;
            pcb.Correto();
            exagonos.GetComponent<Image>().color = Color.yellow;

        }
        else if (isPlaced == true)
        {
            isPlaced = false;
            pcb.Errado();
            exagonos.GetComponent<Image>().color = Color.white;
            
        }


        /*if (possiveisRots >= 1)
        {
            Debug.Log("Passou aqui");
            if (exagonos.transform.rotation.eulerAngles.z == rotacaoCorreta[0] && isPlaced == false)
            {
                Debug.Log("Passou aqui2");
                isPlaced = true;
                pcb.Correto();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                pcb.Errado();
            }
        }
        else
        {
            if (exagonos.transform.eulerAngles.z == rotacaoCorreta[0] && isPlaced == false)
            {
                Debug.Log("Passou aqui2");
                isPlaced = true;
                pcb.Correto();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                pcb.Errado();
            }
        }*/



    }

    public void InteragirFalso()
    {
        exagonos.transform.Rotate(new Vector3(0, 0, 60));
    }



    // Start is called before the first frame update
    public void Start()
    {
        //possiveisRots = rotacaoCorreta.Length;

        // caso a gente queira randomisar como vai mostrar as imagens

        /*int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);


        if (rotacaoCorreta == rotacaoInt && isPlaced == false)
        {
            
            isPlaced = true;
            pcb.Correto();
            exagonos.GetComponent<Image>().color = Color.yellow;
            
        }
        else if (isPlaced == true)
        {
            isPlaced = false;
            pcb.Errado();
            exagonos.GetComponent<Image>().color = Color.white;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (desativaBt == true)
        {
            //exagonos.GetComponent<Button>().interactable = false;
        }
    }
}
