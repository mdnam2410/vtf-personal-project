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
    private Button _backButton;
    [SerializeField]
    private GameObject _pausePanel;

    private void OnValidate()
    {
        _backButton = _pausePanel.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(LoadMainScene);
        _backButton.onClick.AddListener(BackToMainMenu);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        _playButton.SetActive(false);
        Time.timeScale = 1;
    }

    private void BackToMainMenu()
    {
        SceneManager.UnloadSceneAsync("Main");
        //SceneManager.LoadScene("Welcome", LoadSceneMode.Additive);
        _playButton.SetActive(true);
        _pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pausePanel.SetActive(!_pausePanel.activeInHierarchy);
            Cursor.lockState = _pausePanel.activeInHierarchy ? CursorLockMode.None : CursorLockMode.Locked;
            Time.timeScale = _pausePanel.activeInHierarchy ? 0 : 1;
            FindObjectOfType<FPSMouseController>().enabled = !_pausePanel.activeInHierarchy;
        }

        //Input.GetA
    }
}
