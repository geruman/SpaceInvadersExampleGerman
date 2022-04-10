using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealthScript : MonoBehaviour
{
    private int health;
    private void Start()
    {
        health = 3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
