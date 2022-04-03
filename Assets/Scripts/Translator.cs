using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Translator : MonoBehaviour
{
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }

    public void Move(Vector2 velocity)
    {

        rb.velocity = velocity;
    }
    public void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0)
        {
            Vector2 newVelocity = Vector2.zero;
            if (rb.velocity.x>0)
            {
                newVelocity.x = rb.velocity.x -0.01f;
            }
            else if (rb.velocity.x < 0)
            {
                newVelocity.x = rb.velocity.x +0.01f;
            }
            if (rb.velocity.y > 0)
            {
                newVelocity.y = rb.velocity.y -0.01f;
            }
            else if (rb.velocity.y < 0)
            {
                newVelocity.y = rb.velocity.y +0.01f;
            }
            if (newVelocity.magnitude < 0.1f)
            {
                newVelocity = Vector2.zero;
            }
            rb.velocity = newVelocity;
        }
    }

}
