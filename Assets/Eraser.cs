using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private _Toggle toggle;
    private void Start() {
        toggle = FindObjectOfType<_Toggle>();
        if (toggle.GetComponent<Collider2D>().OverlapPoint(transform.position)) {
            toggle.togglable = true;
        }
    }

    
}
