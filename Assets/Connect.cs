using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private Collider2D goal;
    public bool connected = false;
    private bool isDrawing = false;
    // Start is called before the first frame update
    void Start()
    {
        line.SetPosition(0, transform.GetChild(0).position);
        line.SetPosition(1, transform.GetChild(0).position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                {
                    line.SetPosition(1, touchPos);
                    isDrawing = true;
                }
            } else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
                if (isDrawing) {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    line.SetPosition(1, touchPos);
                }
            } else if (touch.phase == TouchPhase.Ended) {
                if (isDrawing) {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    if (goal.OverlapPoint(touchPos)) {
                        line.SetPosition(1, goal.transform.GetChild(0).position);
                        connected = true;
                    } else {
                        line.SetPosition(1, transform.GetChild(0).position);
                        connected = false;
                    }
                    isDrawing = false;

                }
            }
        }
    }
}
