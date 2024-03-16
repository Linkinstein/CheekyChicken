using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D cc2d;
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] public int _x = 1;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] public bool tail = true;

    public int x
    {
        get { return _x; }
        set 
        { 
            if (value < 0 ) sr.flipX = true;
            _x = value;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }
}
