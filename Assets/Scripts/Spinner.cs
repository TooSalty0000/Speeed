using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;
    private float prevAngle;
    private float currentAngle;
    
    public float totalSpin = 5 * 360;
    private float signChangeCount;
    private bool turnRight;
    private void Start() {
        signChangeCount = 361;
    }
    private void Update() {
        prevAngle = transform.eulerAngles.z;
        // rotate the z of object towards the touch position
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector3 direction = touchPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        currentAngle = transform.eulerAngles.z;
        float deltaAngle = currentAngle - prevAngle;
        if (signChangeCount > 360) {
            if (deltaAngle < 0) {
                turnRight = true;
            } else {
                turnRight = false;
            }
            signChangeCount = 0;
        } else {
            if (turnRight) {
                if (deltaAngle > 0) {
                    signChangeCount += deltaAngle;
                } else {
                    signChangeCount = 0;
                    totalSpin -= -deltaAngle;
                }
            } else {
                if (deltaAngle < 0) {
                    signChangeCount += deltaAngle;
                } else {
                    signChangeCount = 0;
                    totalSpin -= deltaAngle;
                }
            }
        }
        text.text = (Mathf.CeilToInt(totalSpin/360)).ToString();
        
    }


}
