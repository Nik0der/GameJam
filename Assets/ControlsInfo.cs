using TMPro;
using UnityEngine;

public class ControlsInfo : MonoBehaviour
{
    public TMP_Text controlsText;

    private void Start()
    {
        controlsText.text =
            "ДВИЖЕНИЕ: WASD\n" +
            "СТРЕЛЬБА: SPACE\n" +
            "СПОСОБНОСТЬ: LEFT SHIFT\n" +
            "ОВЕРДРАЙВ: E\n" +
            "ПАУЗА: ESC";
    }
}