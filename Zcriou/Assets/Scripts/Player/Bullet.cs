using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyGFX>().TakeDamage(50);
        }
    }

}
