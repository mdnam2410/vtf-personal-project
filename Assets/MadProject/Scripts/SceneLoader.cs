using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    [SerializeField]
    private GameObject _playButton;
    [SerializeField]
    private GameObject _backButton;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private GameObject _cancelButton;

    private void Start()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(LoadMainScene);
        _backButton.GetComponent<Button>().onClick.AddListener(BackToMainMenu);
        _pauseButton.GetComponent<Button>().onClick.AddListener(OnPauseButtonClick);
        _cancelButton.GetComponent<Button>().onClick.AddListener(OnCancelButtonClick);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
        _playButton.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Main");
        _playButton.SetActive(true);
        _pausePanel.SetActive(false);
        _pauseButton.SetActive(false);
    }

    private void OnPauseButtonClick()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<FPSMouseController>().enabled = false;
        _pauseButton.SetActive(false);
    }

    private void OnCancelButtonClick()
    {
        _pausePanel.SetActive(false);
        _pauseButton.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<FPSMouseController>().enabled = true;
    }
}
