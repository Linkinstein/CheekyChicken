using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Chicken : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D cc2d;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject[] Spawners;

    private bool stunned = false;
    private bool stunImmune = false;

    private bool[] pickedEggs = new bool[6];
    private int eggs = 0;
    private int collisionStrength = 10;
    private int x = 1;

    private void FixedUpdate()
    {
        if (!stunned)
        {
            if (Input.GetAxis("Horizontal") != 0) x = (int)Mathf.Sign(Input.GetAxis("Horizontal"));
            float slow = 1 - (0.1f * eggs);
            rb.velocity = new Vector2((Input.GetAxis("Horizontal") * moveSpeed)* Mathf.Clamp(slow, 0.1f, 1f), (Input.GetAxis("Vertical") * moveSpeed) * Mathf.Clamp(slow, 0.1f, 1f));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            ResetEggs();
            if (!stunned) StartCoroutine(CarCrash());
            stunned = true;
            if(!stunImmune)rb.velocity = new Vector2((gameObject.transform.position.x - collision.transform.position.x) * collisionStrength, (gameObject.transform.position.y - collision.transform.position.y) * collisionStrength);
            
        }

        if (collision.gameObject.CompareTag("Egg"))
        {
            eggs++;
            gameObject.transform.localScale += new Vector3(0.05f, -0.05f, 0f);
            pickedEggs[collision.gameObject.GetComponent<Egg>().number] = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Homebase"))
        {
            ResetEggs();
        }
    }

    IEnumerator CarCrash()
    {
        yield return new WaitForSeconds(0.3f);
        stunImmune = true;
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1f);
        stunned = false;
        yield return new WaitForSeconds(0.2f);
        stunImmune = false;
    }

    private void ResetEggs()
    {
        gameObject.transform.localScale = Vector3.one;
        eggs = 0;
        for (int i = 0; i < pickedEggs.Length; i++)
        {
            if (pickedEggs[i]) StartCoroutine(Spawners[i].GetComponent<EggSpawner>().Spawning());
            pickedEggs[i] = false;
        }
    }
}
