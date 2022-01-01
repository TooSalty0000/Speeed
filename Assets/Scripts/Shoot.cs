using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private float timer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                transform.position = new Vector3(touchPos.x, transform.position.y);
                shootBullets();
            }
        }
    }

    void shootBullets() {
        if (timer < 0) {
            GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0.1f;
        }
    }
}
