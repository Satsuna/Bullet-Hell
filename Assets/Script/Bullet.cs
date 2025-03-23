using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;
    public float rotation = 0f;
    public float speed = 1f;


    private Vector2 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if(timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer) {
        float x = timer * speed * transform.up.x;
        float y = timer * speed * transform.up.y;
        return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<Boss>(out var health)) {
            health.Damage(1);
            Destroy(this.gameObject);
        }
    }
}
