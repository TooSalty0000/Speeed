using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _Toggle : MonoBehaviour
{
    public bool toggled = false;
    private TextMeshPro text;
    [SerializeField]
    private bool randomPlacement = false;
    public bool togglable = true;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(0).GetComponent<TextMeshPro>();
        if (randomPlacement) {
            transform.position = new Vector3(Random.Range(-1.58f, 1.59f), Random.Range(-3.13f, 0.15f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (toggled) {
            GetComponent<SpriteRenderer>().color = Color.green;
            text.text = "ON";
        } else {
            GetComponent<SpriteRenderer>().color = Color.white;
            text.text = "OFF";
        }
        if (!togglable) {
            return;
        }
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                if (GetComponent<Collider2D>().OverlapPoint(touchPos)) {
                    toggled = !toggled;
                }
            }
        }
    }
}
