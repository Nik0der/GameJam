using TMPro;
using UnityEngine;

public class CreditsInfo : MonoBehaviour
{
    public TMP_Text creditsText;

    private void Start()
    {
        creditsText.text =
            "Сабитов Бронислав - Тимлид, талисман, Дадайкин Андрей - Креативный Директор, Саватеев Артем - Человек беда, Вожжов Владимир - Консось Нових Поколеня, Рестеу Даниил - 2D Дизайнер, Заморский Павел - Звукорежесер, бэкенд, Каменский Никита - Просто хороший человек";
    }
}