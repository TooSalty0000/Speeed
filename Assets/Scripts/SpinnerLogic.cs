using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerLogic : MonoBehaviour
{
    [SerializeField]
    private Spinner spinner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int spins = Mathf.FloorToInt(spinner.totalSpin/360);
        if (spins <= 0) {
            LevelSpawner.instance.nextScene();
        }
    }
}
