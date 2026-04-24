using UnityEngine;
using UnityEngine.UI;

public class TeamEnergy : MonoBehaviour
{
    public static TeamEnergy Instance;

    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float currentEnergy = 100f;
    [SerializeField] private Slider energySlider;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public bool TrySpend(float amount)
    {
        if (currentEnergy < amount) return false;

        currentEnergy -= amount;
        UpdateUI();
        return true;
    }

    public void AddEnergy(float amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + amount, 0, maxEnergy);
        UpdateUI();
    }

    public void StealEnergy(float amount)
    {
        currentEnergy = Mathf.Clamp(currentEnergy - amount, 0, maxEnergy);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (energySlider != null)
            energySlider.value = currentEnergy / maxEnergy;
    }
}