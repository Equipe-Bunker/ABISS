using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Inventario/DadoItem")] 

public class DadoItem : ScriptableObject
{
    public string Nome => _nome;
    public List<string> Descricao => _descricao;
    public Image Sprite => _sprite;

    [SerializeField] private string _nome;
    [SerializeField] private List<string> _descricao;
    [SerializeField] private Image _sprite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
