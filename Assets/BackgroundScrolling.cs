using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{

    private RawImage image;
    [SerializeField]
    private Vector2 speed;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        image.uvRect = new Rect(image.uvRect.x + speed.x * Time.deltaTime, image.uvRect.y + speed.y * Time.deltaTime, 1, 1);
    }
}
