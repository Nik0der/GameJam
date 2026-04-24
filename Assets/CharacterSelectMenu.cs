using TMPro;
using UnityEngine;

public class CharacterSelectMenu : MonoBehaviour
{
    public TMP_Text[] playerCharacterTexts;

    private string[] characters =
    {
        "ТУРБО-ПОГРУЗЧИК",
        "КУРЬЕР Δ",
        "НЯНЯ-7",
        "АРХИВАРИУС.exe"
    };

    private int[] selectedCharacterIndex = { 0, 1, 2, 3 };

    private void Start()
    {
        UpdateTexts();
    }

    public void NextCharacter(int playerIndex)
    {
        if (playerIndex < 0 || playerIndex >= selectedCharacterIndex.Length) return;

        selectedCharacterIndex[playerIndex]++;
        if (selectedCharacterIndex[playerIndex] >= characters.Length)
            selectedCharacterIndex[playerIndex] = 0;

        UpdateTexts();
    }

    public void PrevCharacter(int playerIndex)
    {
        if (playerIndex < 0 || playerIndex >= selectedCharacterIndex.Length) return;

        selectedCharacterIndex[playerIndex]--;
        if (selectedCharacterIndex[playerIndex] < 0)
            selectedCharacterIndex[playerIndex] = characters.Length - 1;

        UpdateTexts();
    }

    private void UpdateTexts()
    {
        for (int i = 0; i < playerCharacterTexts.Length; i++)
        {
            playerCharacterTexts[i].text =
                $"ИГРОК {i + 1}: [ {characters[selectedCharacterIndex[i]]} ]";
        }
    }
}