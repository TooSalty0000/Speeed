using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MouseHandler : MonoBehaviour
{
    private struct touch {
        public int touchID;
        public GameObject effect;
    }

    [SerializeField]
    private GameObject touchEffect;
    private List<touch> touchEffectInstances = new List<touch>();
    // Start is called before the first frame update
    void Start()
    {
        touchEffectInstances = new List<touch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    GameObject newTouchEffect = Instantiate(touchEffect, touchPos, Quaternion.identity);
                    touchEffectInstances.Add(new touch { touchID = Input.GetTouch(i).fingerId, effect = newTouchEffect });
                } else if (Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary) {
                    GameObject _effect = touchEffectInstances.Find(x => x.touchID == Input.GetTouch(i).fingerId).effect;
                    if (_effect) {
                        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                        _effect.transform.position = touchPos;
                    }
                } else if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled) {
                    foreach (var touchEffect in touchEffectInstances) {
                        if (touchEffect.touchID == Input.GetTouch(i).fingerId) {
                            Destroy(touchEffect.effect);
                            touchEffectInstances.Remove(touchEffect);
                            break;
                        }
                    }
                }
            }
        }
        int j = 0;
        while (j < touchEffectInstances.Count) {
            if (touchEffectInstances[j].effect == null) {
                touchEffectInstances.RemoveAt(j);
            } else {
                if (Input.touches.All(x => x.fingerId != touchEffectInstances[j].touchID)) {
                    Destroy(touchEffectInstances[j].effect);
                    touchEffectInstances.RemoveAt(j);
                } else {
                    j++;
                }
            }
        }
    }
    
}
