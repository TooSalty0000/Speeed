using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject touchEffect;
    private List<GameObject> touchEffectInstances = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        touchEffectInstances = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch[] touches = Input.touches;
            for (int i = 0; i < touches.Length; i++)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touches[i].position);
                if (touches[i].phase == TouchPhase.Began) {
                    touchEffectInstances.Add(Instantiate(touchEffect, (Vector3)touches[i].position + new Vector3(0, 0, -5), Quaternion.identity));
                } else if (touches[i].phase == TouchPhase.Moved || touches[i].phase == TouchPhase.Stationary) {
                    touchEffectInstances[i].transform.position = touchPos;
                } else if (touches[i].phase == TouchPhase.Ended || touches[i].phase == TouchPhase.Canceled) {
                    if (touchEffectInstances[i]) {
                        touchEffectInstances[i].GetComponent<ParticleSystem>().Stop();
                        touchEffectInstances[i].gameObject.AddComponent<AutoDestroyer>();
                        touchEffectInstances.RemoveAt(i);
                    } else {
                        touchEffectInstances.RemoveAt(i);
                    }
                }
            }
            
        }
        //loop through touchEffectInstances and check if they exist, if not remove them
        for (int i = 0; i < touchEffectInstances.Count; i++)
        {
            if (touchEffectInstances[i] == null)
            {
                touchEffectInstances.RemoveAt(i);
            }
        }
    }
}
