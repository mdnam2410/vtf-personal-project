using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    [SerializeField]
    private GameObject _canvas;
    [SerializeField]
    private GameObject _playButton;

    private void Start()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(CreateNewGame);
    }

    private void CreateNewGame()
    {
        LoadGameScene();
        _canvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        LoadMainMenuScene();
        _canvas.SetActive(true);
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
