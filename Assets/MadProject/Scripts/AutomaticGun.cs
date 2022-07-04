using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private bool _isWalking;
    private bool _isRunning;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetBool("IsWalking", _isWalking);
        _animator.SetBool("IsRunning", _isRunning);
    }

    public void OnWalking()
    {
        _isWalking = true;
    }

    public void OnStopWalking()
    {
        _isWalking = false;
    }

    public void OnRunning()
    {
        _isRunning = true;
    }

    public void OnStopRunning()
    {
        _isRunning = false;
    }

}
