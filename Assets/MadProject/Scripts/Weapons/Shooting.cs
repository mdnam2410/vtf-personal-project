using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    protected Ammo _ammo;
    [SerializeField]
    protected AudioSource _fireSound;
    [SerializeField]
    protected GameObject _shootButton;

    protected bool _shootButtonDown;
    protected bool _shootButtonUp;

    public UnityEvent OnShoot;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
    }

    private bool _locked;
    public bool Locked
    { 
        get => _locked;
        set
        {
            _locked = value;
        }
    }

    protected void UpdateButtonState()
    {
        _shootButtonDown = _shootButton.GetComponent<PressDetector>().Pressed;
        _shootButtonUp = !_shootButtonDown;
    }

    protected virtual void Shoot()
    {
        if (!Locked)
        {
            _animator.SetTrigger("Fire");
            _ammo.Shoot();
            OnShoot.Invoke();
        }
    }

    public void Lock() => Locked = true;
    
    public void Unlock() => Locked = false;

    public void PlayFireSound()
    {
        _fireSound.Play();
    }
}
