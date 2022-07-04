using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _guns;

    private int _currentGunIndex;

    private void Start()
    {
        _currentGunIndex = (_guns == null || _guns.Length == 0) ? -1 : 0;
    }

    private void Update()
    {
        for (int i = 0; i < _guns.Length; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchToGun(i);
            }
        }
    }

    private void SwitchToGun(int index)
    {
        if (_currentGunIndex == -1) return;
        _guns[_currentGunIndex].SetActive(false);
        _guns[index].SetActive(true);
        _currentGunIndex = index;
    }
}
