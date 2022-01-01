using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField]
    private Sprite[] breaking;
    private Rigidbody2D rb;
    public int breakingLevel = 0;
    public bool broken = false;
    private bool isMoving = false;
    private bool isFalling = false;
    private bool wasHeld = false;
    private float prevY;
    private float dropPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                rb.isKinematic = false;
                rb.gravityScale = 10f;
                if (GetComponent<Collider2D>().OverlapPoint(touchPos)) {
                    isMoving = true;
                    wasHeld = true;
                }
            } else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
                if (isMoving) {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    rb.velocity = Vector2.zero;
                    transform.position = touchPos;
                    
                }
            } else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
                isMoving = false;
                dropPoint = transform.position.y;
            }
        }
        if (transform.position.y < prevY) {
            isFalling = true;
        } else {
            isFalling = false;
        }
        if (breakingLevel < breaking.Length) {
            GetComponent<SpriteRenderer>().sprite = breaking[breakingLevel];
        } else {
            broken = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (dropPoint > 0 && wasHeld)  {
            breakingLevel++;
            dropPoint = -Mathf.Infinity;
        }
    }

}
