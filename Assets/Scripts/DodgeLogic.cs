using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DodgeLogic : MonoBehaviour
{
    [SerializeField]
    private Attacker[] attackers;
    private float timer = 1;
    private int attackerActive = 0;
    [SerializeField]
    private float delay = .8f;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            if (attackerActive < attackers.Length) {
                attackers[attackerActive].isAttacking = true;
                attackerActive++;
            }
            timer = delay;
        }
        if (attackers.All(x => x.transform.position.y < -5.5f)) {
            LevelSpawner.instance.nextScene();
        }
    }
}
