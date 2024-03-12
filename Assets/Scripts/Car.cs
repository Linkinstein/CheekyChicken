using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D cc2d;

    [SerializeField] private float x = 1;
    [SerializeField] private float moveSpeed = 2f;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }

    public void setDir(float dir)
    {
        x = dir;
    }
}
