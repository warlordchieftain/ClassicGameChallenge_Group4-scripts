using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
       Player1 controller = other.GetComponent<Player1>();

        if (controller != null)
        {
           ScoreScript.score += 100;
           Destroy(gameObject);
               
        }

    }
}