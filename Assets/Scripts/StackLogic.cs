using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stacks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allStacked = true;
        // loop through all stacks
        // if all stacks are stacked, and the y position difference is greater than 1.1, next scene
        for (int i = 0; i < stacks.Length; i++)
        {
            if (stacks[i].GetComponent<Stack>().isStacked)
            {
                foreach (var stack in stacks)
                {
                    if (stack != stacks[i] && Mathf.Abs(stack.transform.position.y - stacks[i].transform.position.y) < 1.1f)
                    {
                        allStacked  = false;
                        return;
                    }
                }
            } else {
                allStacked = false;
                break;
            }
        }
        if (allStacked) {
            LevelSpawner.instance.nextScene();
        }
    }
}
