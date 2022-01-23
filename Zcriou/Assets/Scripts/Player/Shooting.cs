using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject check;

    public float bulletForce = 20f;

    public float speed = 1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        check = this.transform.parent.gameObject;
        speed = check.GetComponent<PlayerMovement>().getSpeed();
        //Marche pas à continuer
    }

    void Shoot()
    {
        if (speed != 0f) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}