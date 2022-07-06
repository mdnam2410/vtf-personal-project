using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    private AudioSource _walkingSound;
    [SerializeField]
    private AudioSource _runningSound;

    private bool _isWalking;
    private bool _isRunning;

    private int IsWalkingParameter = Animator.StringToHash("IsWalking");
    private int IsRunningParameter = Animator.StringToHash("IsRunning");

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalkingParameter, _isWalking);
        _animator.SetBool(IsRunningParameter, _isRunning);
    }

    public void OnWalking()
    {
        if (!_walkingSound.isPlaying)
            _walkingSound.Play();
        _isWalking = true;
    }

    public void OnStopWalking()
    {
        if (_walkingSound.isPlaying)
            _walkingSound.Stop();
        _isWalking = false;
    }

    public void OnRunning()
    {
        if (!_runningSound.isPlaying)
            _runningSound.Play();
        _isRunning = true;
    }

    public void OnStopRunning()
    {
        if (_runningSound.isPlaying)
            _runningSound.Stop();
        _isRunning = false;
    }
}
