using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject spot;
    [SerializeField]
    private GameObject tick;
    private bool timed = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //loop through all touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                {
                    animator.Play("Click");
                    animator.SetBool("Pressed", true);
                    // if tick's x position distance from spot is less than half of spot's x scale, then set timed  to true
                    if (Mathf.Abs(tick.transform.position.x - spot.transform.position.x) < spot.transform.localScale.x / 2)
                    {
                        LevelSpawner.instance.nextScene();
                    }
                }
            } else if (touch.phase == TouchPhase.Ended) {
                animator.SetBool("Pressed", false);
            }
        }
    }
}
