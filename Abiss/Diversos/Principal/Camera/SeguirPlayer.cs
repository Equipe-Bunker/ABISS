using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }
}
