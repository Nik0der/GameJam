using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class VerticalMenuNavigation : MonoBehaviour
{
    public Selectable[] buttons;
    public int currentIndex = 0;

    private void OnEnable()
    {
        currentIndex = 0;
        SelectCurrent();
    }

    private void Update()
    {
        if (!gameObject.activeInHierarchy) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = buttons.Length - 1;

            SelectCurrent();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentIndex++;
            if (currentIndex >= buttons.Length)
                currentIndex = 0;

            SelectCurrent();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Button currentButton = buttons[currentIndex] as Button;
            if (currentButton != null)
                currentButton.onClick.Invoke();
        }
    }

    private void SelectCurrent()
    {
        if (buttons == null || buttons.Length == 0) return;

        EventSystem.current.SetSelectedGameObject(null);
        buttons[currentIndex].Select();
    }
}