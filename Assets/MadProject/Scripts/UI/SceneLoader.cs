using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    [SerializeField]
    private GameObject _playButton;

    private void Start()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(CreateNewGame);
    }

    private void CreateNewGame()
    {
        LoadGameScene();
        _playButton.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        LoadMainMenuScene();
        _playButton.SetActive(true);
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
