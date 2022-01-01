using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    [SerializeField]
    private GameObject erasor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                Instantiate(erasor, touchPos, Quaternion.identity);
            }
        }
    }
}
