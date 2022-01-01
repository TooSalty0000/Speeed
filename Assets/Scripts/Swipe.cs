using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    // Start is called before the first frame update
    private float startX;
    private float changeX;
    private Vector3 startPos;
    [SerializeField]
    private bool isRight;
    public bool swiped = false;
    private bool isSwiping;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (swiped) {
            if (isRight) {
                transform.position = Vector3.Lerp(transform.position, new Vector3(30, transform.position.y), 0.1f);
            } else {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-30, transform.position.y), 0.1f);
            }
            
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (hit.collider && hit.collider.gameObject == gameObject)
                {
                    isSwiping = true;
                    startX = touchPos.x;
                }
            }
            if (touch.phase == TouchPhase.Moved) {
                if (isSwiping) {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    changeX = touchPos.x - startX;
                    transform.position = startPos + new Vector3(changeX, 0, 0);
                }
            }
            if (touch.phase == TouchPhase.Ended) {
                isSwiping = false;
                if (isRight) {
                    if (changeX > 1) {
                        swiped = true;
                        return;
                    }
                } else {
                    if (changeX < -1) {
                        swiped = true;
                        return;
                    }
                }
                isSwiping = false;
                transform.position = startPos;
            }
        }
    }
}
