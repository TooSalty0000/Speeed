using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject poppingEffect;
    // Start is called before the first frame update
    void Start()
    {
        // set random direction with magnitude of 1
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //get all touches
            Touch[] touches = Input.touches;
            //loop through all touches
            foreach (Touch touch in touches)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began )
                {
                    if (Vector2.Distance(touchPos, transform.position) < 0.8f)
                    {
                        GameObject Effect = Instantiate(poppingEffect, transform.position, Quaternion.identity);
                        Effect.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
                        Destroy(gameObject);
                    }
                }
            }
        }
        
        // set velocity to direction * speed
        rb.velocity = direction * speed;
    }

    // if collides, change into random direction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ball") {
            // if the point of contact the difference is greater than 0.3, change inverse the x direction
            if (Mathf.Abs(collision.contacts[0].point.x - transform.position.x) > 0.1f)
            {
                direction.x *= -1;
            }
            // if the point of contact the difference is greater than 0.3, change inverse the y direction
            if (Mathf.Abs(collision.contacts[0].point.y - transform.position.y) > 0.1f)
            {
                direction.y *= -1;
            }
        } else {
            // make the direction of the ball the vector from the ball to the contact point
            direction = (Vector2)transform.position - collision.contacts[0].point;
            direction.Normalize();
        }
    }
}
