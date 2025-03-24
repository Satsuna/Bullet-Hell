using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Animator anim;
    public GameObject gameOverUI;
    public Image[] hearts;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = maxHP;
        Time.timeScale = 1;
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
            gameOverUI.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
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
            StartCoroutine(Invincible());
            UpdateHeartsUI();
        }
    }

    IEnumerator Invincible() {
        anim.SetTrigger("Death");
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentHP);
        }
    }
}
