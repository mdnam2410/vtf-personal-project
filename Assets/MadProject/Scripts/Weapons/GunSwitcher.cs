using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _guns;
    [SerializeField]
    private Button _switchButton;

    private int _previousGunIndex;
    private int _currentGunIndex;
    private bool _changed = false;

    private void Start()
    {
        _previousGunIndex = -1;
        _currentGunIndex = (_guns == null || _guns.Length == 0) ? -1 : 0;
        _switchButton.onClick.AddListener(OnSwitchButtonClick);
        AssignGunBehaviours();
    }

    private void Update()
    {
        if (!_changed) return;

        // Switch to next gun, wrap around at the end
        SwitchToGun((_currentGunIndex + 1) % _guns.Length);
        UpdateGunBehaviours();
        _changed = false;
    }

    private void OnSwitchButtonClick()
    {
        _changed = true;
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
        MoveBehaviour _currentGunBehaviour = _currentGun.GetComponent<MoveBehaviour>();
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
        MoveBehaviour _previousGunBehaviour = _previousGun.GetComponent<MoveBehaviour>();
        FPSMoveController _moveController = GetComponent<FPSMoveController>();

        _moveController.OnWalking.RemoveListener(_previousGunBehaviour.OnWalking);
        _moveController.OnRunning.RemoveListener(_previousGunBehaviour.OnRunning);
        _moveController.OnStopWalking.RemoveListener(_previousGunBehaviour.OnStopWalking);
        _moveController.OnStopRunning.RemoveListener(_previousGunBehaviour.OnStopRunning);
    }
}
