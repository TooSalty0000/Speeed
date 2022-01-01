using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour
{
    public bool isCopy = false;
    public bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCopy) {
            if (state) {
                GetComponent<SpriteRenderer>().color = Color.red;
            } else {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        } else {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (GetComponent<Collider2D>().OverlapPoint(touchPos)) {
                    state = !state;
                }
            }

            if (state) {
                GetComponent<SpriteRenderer>().color = Color.blue;
            } else {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
