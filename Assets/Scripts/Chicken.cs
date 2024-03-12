using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chicken : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D cc2d;
    [SerializeField] private float moveSpeed;
    private bool stunned = false;
    private int eggs = 0;
    private int collisionStrength = 5;
    private float x = 1;

    private void FixedUpdate()
    {
        if (!stunned)
        {
            if (Input.GetAxis("Horizontal") != 0) x = Mathf.Sign(Input.GetAxis("Horizontal"));
            rb.velocity = new Vector2((Input.GetAxis("Horizontal") * moveSpeed)*(1-(0.5f*eggs)), (Input.GetAxis("Vertical") * moveSpeed) * (1 - (0.5f * eggs)));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (!stunned) StartCoroutine(carCrash());
            stunned = true;
            rb.velocity = new Vector2((gameObject.transform.position.x - collision.transform.position.x)* collisionStrength, (gameObject.transform.position.y - collision.transform.position.y)* collisionStrength);
        }
        if (collision.gameObject.CompareTag("Egg"))
        {
            eggs++;
            Debug.Log(eggs);
        }
    }

    IEnumerator carCrash()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1.5f);
        stunned = false;
    }
}
