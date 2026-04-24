using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int hp = 3;
    [SerializeField] private GameObject batteryPrefab;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
            Die();
    }

    private void Die()
    {
        if (batteryPrefab != null)
            Instantiate(batteryPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}