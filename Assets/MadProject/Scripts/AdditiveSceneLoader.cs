using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdditiveSceneLoader : MonoBehaviour
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

    private void OnValidate()
    {
        //_backButton = _pausePanel.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(LoadMainScene);
        _backButton.GetComponent<Button>().onClick.AddListener(BackToMainMenu);
        _pauseButton.GetComponent<Button>().onClick.AddListener(OnPauseButtonClick);
        _cancelButton.GetComponent<Button>().onClick.AddListener(OnCancelButtonClick);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        _playButton.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    private void BackToMainMenu()
    {
        SceneManager.UnloadSceneAsync("Main");
        //SceneManager.LoadScene("Welcome", LoadSceneMode.Additive);
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

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    _pausePanel.SetActive(!_pausePanel.activeInHierarchy);
        //    Cursor.lockState = _pausePanel.activeInHierarchy ? CursorLockMode.None : CursorLockMode.Locked;
        //    Time.timeScale = _pausePanel.activeInHierarchy ? 0 : 1;
        //    FindObjectOfType<FPSMouseController>().enabled = !_pausePanel.activeInHierarchy;
        //}

        //Input.GetA
    }
}
