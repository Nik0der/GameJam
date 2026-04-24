using UnityEngine;

public class MITMEnemy : MonoBehaviour
{
    [SerializeField] private float stealAmount = 5f;
    [SerializeField] private float stealInterval = 2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= stealInterval)
        {
            timer = 0f;

            if (TeamEnergy.Instance != null)
                TeamEnergy.Instance.StealEnergy(stealAmount);
        }
    }
}