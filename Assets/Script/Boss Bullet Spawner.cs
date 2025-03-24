using System.Collections;
using UnityEngine;

public class BossBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform target;
    public float fireRate = 0.2f;
    public int bulletCount = 5;
    public float spreadAngle = 30f;
    public float bulletSpeed = 5f;
    
    void Start()
    {
        StartCoroutine(startShooting());
    }

    void Shoot()
    {   
        if (target != null) {
            Vector2 direction = (target.position - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        }

    }

    void SpreadShoot() {
        float startAngle = -spreadAngle / 2f;
        float angleStep = spreadAngle / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + (angleStep * i);
            Quaternion bulletRotation = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = bulletRotation * Vector2.up * bulletSpeed;
            }
        }
    }

    IEnumerator startShooting() {
        while (true) {
            Invoke("Shoot", 0.2f);
            Invoke("Shoot", 0.4f);
            Invoke("Shoot", 0.6f);
            Invoke("Shoot", 0.8f);
            Invoke("Shoot", 1f);
            yield return new WaitForSeconds(2f);
            Invoke("SpreadShoot", 0.3f);
            Invoke("SpreadShoot", 0.6f);
            Invoke("SpreadShoot", 0.9f);
            Invoke("SpreadShoot", 1.2f);
            Invoke("SpreadShoot", 1.5f);
            yield return new WaitForSeconds(2f);
        }

    }
}
