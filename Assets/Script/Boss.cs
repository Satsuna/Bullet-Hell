using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Slider slider;
    public int maxHP = 100;
    private int currentHP;
    public GameObject winUI;

    void Start () {
        currentHP = maxHP;
        slider.maxValue = maxHP;
        slider.value = currentHP;
    }

    public void Damage(int damage) {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            Destroy(gameObject);
            winUI.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            slider.value = currentHP;
        }
    }
}