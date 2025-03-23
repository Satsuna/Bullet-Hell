using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHP = 3;
    private int hp;

    public int MaxHP => maxHP;

    public int Hp {
        get => hp;
        private set {
            var isDamage = value < hp;
            hp = Mathf.Clamp(value, 0, maxHP);
            if (isDamage) {
                Damaged?.Invoke(hp);
            }

            if (hp <= 0) {
                Died?.Invoke();
            }

        }
    }
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    private void Awake() {
        hp = maxHP;
    }

    public void Damage(int amount) => Hp -= amount;
    public void Kill() => Hp -= 0;
    public void Adjust(int value) => Hp = value;
}