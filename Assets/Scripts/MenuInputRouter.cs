using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputRouter : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private bool gameplayScene = false;

    private bool isPaused = false;

    private void Update()
    {
        if (Keyboard.current == null || menuManager == null) return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (gameplayScene)
            {
                if (!isPaused)
                {
                    menuManager.PauseGame();
                    isPaused = true;
                }
                else
                {
                    menuManager.ResumeGame();
                    isPaused = false;
                }
            }
            else
            {
                menuManager.BackFromSubMenu();
            }
        }
    }

    public void ResumeFromPause()
    {
        menuManager.ResumeGame();
        isPaused = false;
    }

    public void ReturnToMenu()
    {
        menuManager.ReturnToMenuFromPause();
        isPaused = false;
    }
}