using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Transform player;
    private Player1 playerone;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float detectionRange;
    public bool closeEnough;
    public int RATHP = 2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameObject playeroneObject = GameObject.FindWithTag("PlayerTag");
        if(playeroneObject != null)
        {
            playerone = playeroneObject.GetComponent<Player1>();
        }

        player = playerone.transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= detectionRange)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            closeEnough = true;
                }
        else closeEnough = false;
    }
           private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Player1 player = other.gameObject.GetComponent<Player1>();

        if (player != null)
        {
            Player1.HP -= 10;
            Destroy(gameObject);
        }
        if (GameObject.FindWithTag("Spatula"))
        {
            RATHP -= 1;
            if (RATHP <= 0)
            {
                ScoreScript.score += 10;
                Destroy(gameObject);
            }
        }
    }
}
