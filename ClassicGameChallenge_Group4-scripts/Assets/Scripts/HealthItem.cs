using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Player1 controller = other.GetComponent<Player1>();

        if (controller != null)
        {
            if (Player1.HP < Player1.maxHealth)
            {
                controller.ChangeHealth(50);
                Destroy(gameObject);
               

            }
        }

    }
}