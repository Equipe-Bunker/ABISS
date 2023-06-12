using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braco : MonoBehaviour
{
    void Update()
    {
        if(Time.timeScale == 1)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            transform.rotation = rotation;


            /*Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posMouse.z = transform.position.z;
            transform.right = posMouse - transform.position;*/
        }
    }
}
