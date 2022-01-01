using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    private Transform dodge;
    [SerializeField]
    private float speed;
    public bool isAttacking = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking) {
            Vector3 direction = dodge.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } else {
            rb.velocity = transform.up * speed;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Dodger") {
            LevelSpawner.instance.resetLevel();
        }
    }
}
