using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private GameObject resetButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    GameObject newParticle = Instantiate(particle, touchPos, Quaternion.identity);
                }
            }
            
        }
        if (transform.position.x < -1.5 || transform.position.x > 2.25) {
            resetButton.SetActive(true);
        }
    }
}
