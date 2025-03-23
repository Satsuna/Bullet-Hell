using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(100.0f, 100.0f);
    private new Rigidbody2D rigidbody2D;
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);

    public GameObject bulletPrefab;
    public Transform firePoint;
    private float firingRate = 0.1f;
    private float fireCooldown = 0;

    public int maxHP = 3;
    private int currentHP;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    void Update()
    {
        //user input movement to pre
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.J) && fireCooldown <= 0f) {
            Shoot();
            fireCooldown = firingRate;
        }

        if (currentHP <= 0) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        //movement update to
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bullet")) {
            currentHP -= 1;
        }
    }
}
