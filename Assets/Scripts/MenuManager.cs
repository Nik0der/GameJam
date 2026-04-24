using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject soloPanel;
    [SerializeField] private GameObject coopPanel;
    [SerializeField] private GameObject characterSelectPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private GameObject videoPanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject pausePanel;

    private GameObject currentPanel;

    private void Start()
    {
        Time.timeScale = 1f;
        OpenPanel(mainMenuPanel);
    }

    public void OpenPanel(GameObject panel)
    {
        if (panel == null) return;

        CloseAllPanels();
        panel.SetActive(true);
        currentPanel = panel;
    }

    public void CloseAllPanels()
    {
        GameObject[] panels =
        {
            mainMenuPanel,
            soloPanel,
            coopPanel,
            characterSelectPanel,
            settingsPanel,
            soundPanel,
            videoPanel,
            controlsPanel,
            creditsPanel,
            pausePanel
        };

        foreach (GameObject panel in panels)
        {
            if (panel != null)
                panel.SetActive(false);
        }
    }

    public GameObject GetCurrentPanel()
    {
        return currentPanel;
    }

    public void OpenMainMenu() => OpenPanel(mainMenuPanel);
    public void OpenSoloMenu() => OpenPanel(soloPanel);
    public void OpenCoopMenu() => OpenPanel(coopPanel);
    public void OpenCharacterSelect() => OpenPanel(characterSelectPanel);
    public void OpenSettings() => OpenPanel(settingsPanel);
    public void OpenSoundSettings() => OpenPanel(soundPanel);
    public void OpenVideoSettings() => OpenPanel(videoPanel);
    public void OpenControls() => OpenPanel(controlsPanel);
    public void OpenCredits() => OpenPanel(creditsPanel);

    public void BackFromSubMenu()
    {
        if (currentPanel == soundPanel || currentPanel == videoPanel || currentPanel == controlsPanel)
        {
            OpenPanel(settingsPanel);
            return;
        }

        if (currentPanel == soloPanel || currentPanel == coopPanel || currentPanel == settingsPanel || currentPanel == creditsPanel)
        {
            OpenPanel(mainMenuPanel);
            return;
        }

        if (currentPanel == characterSelectPanel)
        {
            OpenPanel(coopPanel);
            return;
        }

        if (currentPanel == pausePanel)
        {
            ResumeGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("START GAME");
        SceneManager.LoadScene("Game");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        OpenPanel(pausePanel);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        CloseAllPanels();
        currentPanel = null;
    }

    public void ReturnToMenuFromPause()
    {
        Time.timeScale = 1f;
        OpenPanel(mainMenuPanel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}