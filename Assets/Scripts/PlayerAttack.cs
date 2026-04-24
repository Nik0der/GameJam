using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float bulletSpeed = 12f;
    [SerializeField] private float energyCost = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(float direction)
    {
        if (TeamEnergy.Instance == null) return;

        if (!TeamEnergy.Instance.TrySpend(energyCost))
        {
            Debug.Log("Нет энергии");
            return;
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            shootPoint.position,
            Quaternion.identity
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
            bulletScript.SetDopplerPower(rb.velocity.magnitude);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
            bulletRb.velocity = new Vector2(direction * bulletSpeed, 0f);
    }
}