using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyMenu : MonoBehaviour
{
    [System.Serializable]
    public class PlayerSlot
    {
        public GameObject joinButton;
        public GameObject leftButton;
        public GameObject rightButton;
        public Image characterImage;
        public TMP_Text playerText;
    }

    [Header("Slots")]
    [SerializeField] private PlayerSlot[] slots;

    [Header("Characters")]
    [SerializeField] private Sprite[] characterSprites;
    [SerializeField] private string[] characterNames;

    private bool[] joined = new bool[4];
    private int[] selected = new int[4];

    private void OnEnable()
    {
        UpdateAllSlots();
    }

    public void JoinPlayer0() => JoinPlayer(0);
    public void JoinPlayer1() => JoinPlayer(1);
    public void JoinPlayer2() => JoinPlayer(2);
    public void JoinPlayer3() => JoinPlayer(3);

    public void Next0() => NextCharacter(0);
    public void Next1() => NextCharacter(1);
    public void Next2() => NextCharacter(2);
    public void Next3() => NextCharacter(3);

    public void Prev0() => PrevCharacter(0);
    public void Prev1() => PrevCharacter(1);
    public void Prev2() => PrevCharacter(2);
    public void Prev3() => PrevCharacter(3);

    private void JoinPlayer(int index)
    {
        joined[index] = true;
        SaveData();
        UpdateSlot(index);
    }

    private void NextCharacter(int index)
    {
        selected[index]++;

        if (selected[index] >= characterSprites.Length)
            selected[index] = 0;

        SaveData();
        UpdateSlot(index);
    }

    private void PrevCharacter(int index)
    {
        selected[index]--;

        if (selected[index] < 0)
            selected[index] = characterSprites.Length - 1;

        SaveData();
        UpdateSlot(index);
    }

    private void UpdateAllSlots()
    {
        for (int i = 0; i < slots.Length; i++)
            UpdateSlot(i);
    }

    private void UpdateSlot(int index)
    {
        bool isJoined = joined[index];

        slots[index].joinButton.SetActive(!isJoined);
        slots[index].leftButton.SetActive(isJoined);
        slots[index].rightButton.SetActive(isJoined);
        slots[index].characterImage.gameObject.SetActive(isJoined);

        if (isJoined)
        {
            slots[index].characterImage.sprite = characterSprites[selected[index]];
            slots[index].playerText.text = $"ИГРОК {index + 1}: {characterNames[selected[index]]}";
        }
        else
        {
            slots[index].playerText.text = $"ИГРОК {index + 1}: НЕ ПОДКЛЮЧЕН";
        }
    }

    private void SaveData()
    {
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            GameData.joinedPlayers[i] = joined[i];
            GameData.selectedCharacters[i] = selected[i];

            if (joined[i])
                count++;
        }

        GameData.playersCount = count;
    }
}