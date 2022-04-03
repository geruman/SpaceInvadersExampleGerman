using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    public float maxSpeed = 30f;
    public float speed = 1f;
    public AudioSource shootingSound;
    // Se llama a Start antes de la primera actualización del cuadro

    void Start()
    {
        int randomX = Random.Range(-9, 9);
        transform.position = new Vector3(randomX, transform.position.y, 0);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(moveHorizontal, 0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootingSound.Play();
        }
    }

    // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
    void FixedUpdate()
    {
        // Aplica la fuerza al Rigidbody2d
        rigidbody.AddForce(movement * speed * 50f);
        ClampMaxSpeed();
        //DecreaseSpeed();
    }

    private void DecreaseSpeed()
    {
        if (rigidbody.velocity.magnitude > 0)
        {
            Vector2 newVelocity = Vector2.zero;
            if (rigidbody.velocity.x>0)
            {
                newVelocity.x = rigidbody.velocity.x -0.01f;
            }
            else if (rigidbody.velocity.x < 0)
            {
                newVelocity.x = rigidbody.velocity.x +0.01f;
            }
            if (rigidbody.velocity.y > 0)
            {
                newVelocity.y = rigidbody.velocity.y -0.01f;
            }
            else if (rigidbody.velocity.y < 0)
            {
                newVelocity.y = rigidbody.velocity.y +0.01f;
            }
            if (newVelocity.magnitude < 0.1f)
            {
                newVelocity = Vector2.zero;
            }
            rigidbody.velocity = newVelocity;
        }
    }

    private void ClampMaxSpeed()
    {
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}