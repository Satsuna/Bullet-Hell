using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;
    public int maxHP = 100;
    private int currentHP;

    void Start () {
        currentHP = maxHP;
    }

    public void Damage(int damage) {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            slider.value = currentHP;
        }
    }
}