using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int baseDamage = 1;
    [SerializeField] private float lifeTime = 2f;

    private int finalDamage;

    private void Start()
    {
        finalDamage = baseDamage;
        Destroy(gameObject, lifeTime);
    }

    public void SetDopplerPower(float playerSpeed)
    {
        finalDamage = playerSpeed > 5f ? baseDamage + 1 : baseDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(finalDamage);
            Destroy(gameObject);
        }
    }
}