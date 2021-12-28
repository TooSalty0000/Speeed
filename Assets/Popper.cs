using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popper : MonoBehaviour
{
    [SerializeField]
    private GameObject poppingEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //using ios touch input
        //if user touches the object, destroy this object and instantiate popping effect
        if (Input.touchCount > 0)
        {
            //get all touches
            Touch[] touches = Input.touches;
            //loop through all touches
            foreach (Touch touch in touches)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                    {
                        GameObject Effect = Instantiate(poppingEffect, transform.position, Quaternion.identity);
                        Effect.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
