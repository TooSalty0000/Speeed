using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private _Toggle[] toggles;
    private void Start() {
        toggles = FindObjectsOfType<_Toggle>();
        foreach (var toggle in toggles)
        {
            if (toggle.GetComponent<Collider2D>().OverlapPoint(transform.position)) {
                toggle.togglable = true;
            }
        }
    }

    
}
