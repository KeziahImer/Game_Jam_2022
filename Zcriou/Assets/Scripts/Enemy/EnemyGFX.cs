using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public float speed = 3f;
    public Transform target;

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f) {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }    
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "BasicWizard")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
            Debug.Log("Bonjour");
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
}