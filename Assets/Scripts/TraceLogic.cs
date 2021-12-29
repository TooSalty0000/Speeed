using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject path;
    [SerializeField]
    private GameObject end;

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
                        end.GetComponent<SpriteRenderer>().enabled = true;
                        tracing = true;
                    }
                }
            } else if (touch.phase == TouchPhase.Moved) {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null && tracing) {
                    if (hit.collider.gameObject.name == "End") {
                        LevelSpawner.instance.nextScene();
                    }
                } else if (hit.collider == null) {
                    tracing = false;
                    start.GetComponent<SpriteRenderer>().enabled = true;
                    end.GetComponent<SpriteRenderer>().enabled = false;
                }
            } else if (touch.phase == TouchPhase.Ended) {
                tracing = false;
                start.GetComponent<SpriteRenderer>().enabled = true;
                end.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
