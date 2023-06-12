using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    [SerializeField] private Transform destino;


    public Transform GetDestination()
    {
        return destino;
    }

    
}
