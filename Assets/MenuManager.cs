using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject soloPanel;
    public GameObject coopPanel;
    public GameObject characterSelectPanel;
    public GameObject settingsPanel;
    public GameObject soundPanel;
    public GameObject videoPanel;
    public GameObject controlsPanel;
    public GameObject creditsPanel;
    public GameObject pausePanel;

    private GameObject currentPanel;
    private GameObject previousPanel;

    private void Start()
    {
        Time.timeScale = 1f;
        OpenPanel(mainMenuPanel);
    }

    private void Update()
    {
        if (KeyboardBackPressed())
        {
            HandleBack();
        }
    }

    private bool KeyboardBackPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public void OpenPanel(GameObject panel)
    {
        if (panel == null) return;

        if (currentPanel != null && currentPanel != panel)
            previousPanel = currentPanel;

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

    public void HandleBack()
    {
        if (currentPanel == mainMenuPanel)
            return;

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
            OpenPanel(soloPanel);
            return;
        }

        if (currentPanel == pausePanel)
        {
            ResumeGame();
        }
    }

    public void BackToMainMenu()
    {
        OpenPanel(mainMenuPanel);
    }

    public void OpenSoloMenu() => OpenPanel(soloPanel);
    public void OpenCoopMenu() => OpenPanel(coopPanel);
    public void OpenCharacterSelect() => OpenPanel(characterSelectPanel);
    public void OpenSettings() => OpenPanel(settingsPanel);
    public void OpenSoundSettings() => OpenPanel(soundPanel);
    public void OpenVideoSettings() => OpenPanel(videoPanel);
    public void OpenControls() => OpenPanel(controlsPanel);
    public void OpenCredits() => OpenPanel(creditsPanel);

    public void StartGame()
    {
        Debug.Log("Start Game");
        // SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
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
}