using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float energyAmount = 15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController2D>() != null)
        {
            TeamEnergy.Instance.AddEnergy(energyAmount);
            Destroy(gameObject);
        }
    }
}