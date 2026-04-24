using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public MenuManager menuManager;
    public bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void Resume()
    {
        menuManager.ResumeGame();
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        menuManager.ReturnToMenuFromPause();
        isPaused = false;
    }
}