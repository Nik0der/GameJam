using TMPro;
using UnityEngine;

public class CreditsInfo : MonoBehaviour
{
    public TMP_Text creditsText;

    private void Start()
    {
        creditsText.text =
            "OVERDRIVE: AI RAMPAGE\n\n" +
            "КОМАНДА:\n" +
            "- Имя 1 — Программирование\n" +
            "- Имя 2 — Арт\n" +
            "- Имя 3 — Геймдизайн / Звук";
    }
}