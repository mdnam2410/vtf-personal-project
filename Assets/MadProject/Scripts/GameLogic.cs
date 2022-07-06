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

    private void LateUpdate()
    {
        //if (_zombieManager.DeadZombiesCount == _zombieManager.MaxZombies)
        //{
        //    Debug.Log("Player wins");
        //}
        //else if (_player.GetComponent<HP>().CurrentHP == 0)
        //{
        //    Debug.Log("Zombie wins");
        //}
        //else
        //{
        //    for (int i = 0; i < _victims.Count; ++i)
        //    {
        //        if (_victims[i].GetComponent<HP>().CurrentHP == 0)
        //        {
        //            Debug.Log($"Zombie wins because victim {i} dies");
        //        }
        //    }
        //}
    }
}
