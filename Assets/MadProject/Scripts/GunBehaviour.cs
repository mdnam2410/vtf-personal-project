using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Animator _animator;

    private bool _isWalking;
    private bool _isRunning;

    private int IsWalkingParameter = Animator.StringToHash("IsWalking");
    private int IsRunningParameter = Animator.StringToHash("IsRunning");

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        _animator.SetBool(IsWalkingParameter, _isWalking);
        _animator.SetBool(IsRunningParameter, _isRunning);
    }

    public void OnWalking() => _isWalking = true;

    public void OnStopWalking() => _isWalking = false;
    
    public void OnRunning() => _isRunning = true;

    public void OnStopRunning() => _isRunning = false;
}
