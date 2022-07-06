using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private GameObject _backButton;
    [SerializeField]
    private GameObject _cancelButton;

    void Start()
    {
        _pauseButton.GetComponent<Button>().onClick.AddListener(OnPauseButtonClick);
        _backButton.GetComponent<Button>().onClick.AddListener(BackToMainMenu);
        _cancelButton.GetComponent<Button>().onClick.AddListener(OnCancelButtonClick);

        _pauseButton.SetActive(true);
        _pausePanel.SetActive(false);
    }

    private void OnPauseButtonClick()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<FPSMouseController>().enabled = false;
        _pauseButton.SetActive(false);
    }

    public void BackToMainMenu()
    {
        _pausePanel.SetActive(false);
        _pauseButton.SetActive(false);
        SceneLoader.Instance.ReturnToMainMenu();
    }

    private void OnCancelButtonClick()
    {
        _pausePanel.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1;
        FindObjectOfType<FPSMouseController>().enabled = true;
    }
}
