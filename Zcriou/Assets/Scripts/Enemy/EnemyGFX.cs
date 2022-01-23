using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float speed = 3f;
    public Transform target;
    public int dmg;

    public int maxHealth = 100;
    public int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f) {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }

        if (currentHealth == 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BasicWizard") {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "BasicWizard") {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }


    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}