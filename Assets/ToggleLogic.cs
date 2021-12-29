using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ToggleLogic : MonoBehaviour
{
    private GameObject[] toggles;
    // Start is called before the first frame update
    void Start()
    {
        toggles = GameObject.FindGameObjectsWithTag("Toggle");
        for(int i = 0; i < Mathf.RoundToInt(toggles.Length/2) + Random.Range(-1, 1); i++)
        {
            toggles[i].GetComponent<_Toggle>().toggled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (toggles.All(x => x.GetComponent<_Toggle>().toggled))
        {
            LevelSpawner.instance.nextScene();
        }
    }
}
