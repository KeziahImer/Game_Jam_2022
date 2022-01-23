using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
<<<<<<< HEAD
=======

        //check = this.transform.parent.gameObject;
        //speed = check.GetComponent<PlayerMovement>().getSpeed();
        //Marche pas à continuer
>>>>>>> 82e32217cf8243d855f653371433350901d1f29e
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}