using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + speed * transform.up * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Ship")
        {
            return;
        }
        Destroy(gameObject);
    }
}
