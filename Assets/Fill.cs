using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    public List<GameObject> particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = new List<GameObject>();
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
                    newParticle.GetComponent<Particle>().fill = this;
                    particles.Add(newParticle);
                }
            }
            
        }
    }
}
