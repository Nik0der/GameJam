using TMPro;
using UnityEngine;

public class CoopMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text[] playerTexts;
    private bool[] connected = new bool[4];

    private void Awake()
    {
        if (playerTexts == null || playerTexts.Length != 4)
        {
            Debug.LogError("CoopMenu: нужно назначить ровно 4 TMP_Text в playerTexts");
        }
    }

    private void OnEnable()
    {
        UpdateTexts();
    }

    public void TogglePlayer0() => TogglePlayer(0);
    public void TogglePlayer1() => TogglePlayer(1);
    public void TogglePlayer2() => TogglePlayer(2);
    public void TogglePlayer3() => TogglePlayer(3);

    public void TogglePlayer(int index)
    {
        if (playerTexts == null || playerTexts.Length != 4)
        {
            Debug.LogError("CoopMenu: playerTexts не настроен");
            return;
        }

        if (index < 0 || index >= connected.Length)
        {
            Debug.LogError($"CoopMenu: неверный index {index}");
            return;
        }

        connected[index] = !connected[index];
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        for (int i = 0; i < 4; i++)
        {
            if (playerTexts[i] == null)
            {
                Debug.LogError($"CoopMenu: playerTexts[{i}] не назначен");
                continue;
            }

            playerTexts[i].text = connected[i]
                ? $"ИГРОК {i + 1}: ГОТОВ"
                : $"ИГРОК {i + 1}: НЕ ПОДКЛЮЧЕН";
        }
    }
}