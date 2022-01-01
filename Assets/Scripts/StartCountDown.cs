using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountDown : MonoBehaviour
{
    public float startCountDown = 3f;
    [SerializeField]
    private TextMeshPro countDownText;
    
    [SerializeField]
    private bool debugging;
    // Start is called before the first frame update
    void Start()
    {
        if (debugging) {
            Destroy(countDownText);
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDown > 0) {
            startCountDown -= Time.deltaTime;
            countDownText.text = Mathf.CeilToInt(startCountDown).ToString();
        } else {
            LevelSpawner.instance.nextScene();  
            Destroy(countDownText.gameObject);
            Destroy(this);
        }
    }
}
