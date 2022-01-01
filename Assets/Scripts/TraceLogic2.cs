using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceLogic2 : MonoBehaviour
{
    [SerializeField]
    private GameObject start;
    private int point = 0;
    [SerializeField]
    private GameObject[] points;

    private bool tracing = false;

    private void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null) {
                    if (hit.collider.gameObject.name == "Start") {
                        start.GetComponent<SpriteRenderer>().enabled = false;
                        point = 0;
                        points[point].GetComponent<SpriteRenderer>().enabled = true;
                        tracing = true;
                    }
                }
            } else if (touch.phase == TouchPhase.Moved) {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null && tracing) {
                    if (hit.collider.gameObject.name == "End") {
                        LevelSpawner.instance.nextScene();
                    } else if (hit.collider.gameObject.tag == "Point") {
                        points[point].GetComponent<SpriteRenderer>().enabled = false;
                        points[point].GetComponent<Collider2D>().enabled = false;
                        point++;
                        points[point].GetComponent<SpriteRenderer>().enabled = true;
                    }
                } else if (hit.collider == null) {
                    tracing = false;
                    start.GetComponent<SpriteRenderer>().enabled = true;
                    foreach (GameObject point in points) {
                        point.GetComponent<SpriteRenderer>().enabled = false;
                        point.GetComponent<Collider2D>().enabled = true;

                    }
                }
            } else if (touch.phase == TouchPhase.Ended) {
                tracing = false;
                start.GetComponent<SpriteRenderer>().enabled = true;
                foreach (GameObject point in points) {
                    point.GetComponent<SpriteRenderer>().enabled = false;
                    point.GetComponent<Collider2D>().enabled = true;
                }
            }
        }
    }
}
