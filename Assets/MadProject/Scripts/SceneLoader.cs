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

    private const int PausePanelUILayer = 10;

    private void Start()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(LoadMainScene);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
        FindPausePanel();
        _playButton.SetActive(false);
        _pauseButton.SetActive(true);
        _pausePanel.SetActive(true);
        Time.timeScale = 1;
    }

    private void FindPausePanel()
    {
        //GameObject[] objects = FindObjectsOfType<GameObject>();
        //for (int i = 0; i < objects.Length; ++i)
        //{
        //    if (objects[i].layer == PausePanelUILayer)
        //    {
        //        GameObject.Find("")
        //    }
        //}
        _pausePanel = GameObject.Find("PausePanel");
        _pauseButton = GameObject.Find("PauseButton");
        _backButton = GameObject.Find("BackToMainMenuButton");
        _cancelButton = GameObject.Find("CancelButton");
        _backButton.GetComponent<Button>().onClick.AddListener(BackToMainMenu);
        _pauseButton.GetComponent<Button>().onClick.AddListener(OnPauseButtonClick);
        _cancelButton.GetComponent<Button>().onClick.AddListener(OnCancelButtonClick);
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
