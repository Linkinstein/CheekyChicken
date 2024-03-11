using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chicken : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc2d;
    [SerializeField] private float moveSpeed;
    bool stunned = false;
    int eggs = 0;

    private void FixedUpdate()
    {
        if (!stunned)
        {
            rb.velocity = new Vector2((Input.GetAxis("Horizontal") * moveSpeed)*(1-(0.5f*eggs)), (Input.GetAxis("Vertical") * moveSpeed) * (1 - (0.5f * eggs)));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (!stunned)
            { 
                stunned = true;
                rb.velocity = new Vector2(gameObject.transform.position.x - collision.transform.position.x, gameObject.transform.position.y - collision.transform.position.y);
            }
        }
    }
}
