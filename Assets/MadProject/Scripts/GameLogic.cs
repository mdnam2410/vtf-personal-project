using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private ZombieManager _zombieManager;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private List<GameObject> _victims;

    [SerializeField]
    private GameObject _victoryPanel;
    [SerializeField]
    private GameObject _defeatPanel;
    [SerializeField]
    private GameObject _backButton;

    private bool _gameEnd;

    private void LateUpdate()
    {
        if (_gameEnd) return;

        bool victory = false;

        // Player is killed
        if (_player.GetComponent<Health>().CurrentHP == 0)
        {
            _gameEnd = true;
        }
        // All zombies are killed
        else if (_zombieManager.DeadZombiesCount == _zombieManager.MaxZombies)
        {
            _gameEnd = true;
            victory = true;
        }
        else
        {
            // All victims are killed
            for (int i = 0; i < _victims.Count; ++i)
            {
                if (_victims[i].GetComponent<Health>().CurrentHP == 0)
                {
                    victory = false;
                    _gameEnd = true;
                    break;
                }
            }
        }

        if (!_gameEnd) return;

        Time.timeScale = 0;
        _backButton.SetActive(true);
        if (victory)
            OnVictory();
        else
            OnDefeat();
    }

    private void OnVictory()
    {
        _victoryPanel.SetActive(true);
    }

    private void OnDefeat()
    {
        _defeatPanel.SetActive(true);
    }
}
