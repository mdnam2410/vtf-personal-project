using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _guns;

    private int _previousGunIndex;
    private int _currentGunIndex;

    private void Start()
    {
        _previousGunIndex = -1;
        _currentGunIndex = (_guns == null || _guns.Length == 0) ? -1 : 0;
        AssignGunBehaviours();
    }

    private void Update()
    {
        bool hasChange = false;
        for (int i = 0; i < _guns.Length; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (i != _currentGunIndex)
                {
                    hasChange = true;
                    SwitchToGun(i);
                }
            }
        }

        if (hasChange)
            UpdateGunBehaviours();
    }

    private void SwitchToGun(int index)
    {
        if (_currentGunIndex == -1) return;
        _guns[_currentGunIndex].SetActive(false);
        _guns[index].SetActive(true);
        _previousGunIndex = _currentGunIndex;
        _currentGunIndex = index;
    }

    private void UpdateGunBehaviours()
    {
        RemoveListernersOfPreviousGun();
        AssignGunBehaviours();
    }

    private void AssignGunBehaviours()
    {
        if (_currentGunIndex == -1) return;
        GameObject _currentGun = _guns[_currentGunIndex];
        GunBehaviour _currentGunBehaviour = _currentGun.GetComponent<GunBehaviour>();
        FPSMoveController _moveController = GetComponent<FPSMoveController>();

        _moveController.OnWalking.AddListener(_currentGunBehaviour.OnWalking);
        _moveController.OnRunning.AddListener(_currentGunBehaviour.OnRunning);
        _moveController.OnStopWalking.AddListener(_currentGunBehaviour.OnStopWalking);
        _moveController.OnStopRunning.AddListener(_currentGunBehaviour.OnStopRunning);
    }

    private void RemoveListernersOfPreviousGun()
    {
        if (_previousGunIndex == -1)
            return;

        GameObject _previousGun = _guns[_currentGunIndex];
        GunBehaviour _previousGunBehaviour = _previousGun.GetComponent<GunBehaviour>();
        FPSMoveController _moveController = GetComponent<FPSMoveController>();

        _moveController.OnWalking.RemoveListener(_previousGunBehaviour.OnWalking);
        _moveController.OnRunning.RemoveListener(_previousGunBehaviour.OnRunning);
        _moveController.OnStopWalking.RemoveListener(_previousGunBehaviour.OnStopWalking);
        _moveController.OnStopRunning.RemoveListener(_previousGunBehaviour.OnStopRunning);
    }
}
