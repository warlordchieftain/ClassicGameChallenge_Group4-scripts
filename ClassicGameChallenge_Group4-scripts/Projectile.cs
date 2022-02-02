using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float timeAttacking = 1.0f;
    bool isAttacking;
    float attackingTimer;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        Player1.speed = 0.0f;   
        if (Player1.speed == 0){
            if (isAttacking)
            return;

            isAttacking = true;
            attackingTimer = timeAttacking;
        }
        
    }   

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }

        if (isAttacking)
        {
            attackingTimer -= Time.deltaTime;
            if (attackingTimer < 0)
                isAttacking = false;
        }

        if (isAttacking == false)
        {
            Player1.speed = 3.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
