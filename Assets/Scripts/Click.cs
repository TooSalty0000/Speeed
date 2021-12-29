using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;

public class Click : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro clickCountText;
    [SerializeField]
    private ParticleSystem clikcParticle;
    public int clickCount = 10;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        clickCountText.text = clickCount.ToString();
        Touch[] touches = Input.touches;
        //loop through all touches
        foreach (Touch touch in touches)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                {
                    clickCount--;
                    animator.Play("Click");
                }
            }
        }
    }
}
