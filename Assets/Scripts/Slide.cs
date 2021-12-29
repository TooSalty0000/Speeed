using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    private bool moving = false;
    private Collider2D col;
    [SerializeField]
    private Vector2 xlimits;
    public bool slided = false;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if user touches the object, allow the user to drag it around
        // use ios touch input
        if (Input.touchCount > 0)
        {
            //get all touches
            Touch touch = Input.GetTouch(0);
            //loop through all touches
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (col.OverlapPoint(touchPos))
                {
                    moving = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (moving)
                {
                    transform.position = Vector3.Lerp(new Vector2(Mathf.Clamp(touchPos.x, xlimits.x, xlimits.y), transform.position.y), transform.position, 0.1f);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                moving = false;
                if (Mathf.Abs(transform.position.x - xlimits.y) < 0.1f)
                {
                    slided = true;
                    GetComponent<SpriteRenderer>().color = Color.green;
                    enabled = false;
                }
            }
        }
    }
}
