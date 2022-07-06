using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AutomaticFireBehaviour : Shooting
{
    [SerializeField]
    private float _rpm;

    private float Interval
    {
        get => 60 / _rpm;
    }

    private bool _isFiring;
    private float _lastShotTime;

    private void Update()
    {
        UpdateButtonState();
        if (_fireButtonUp || _ammo.LoadedAmmo == 0)
        {
            _isFiring = false;
        }
        else if (_fireButtonDown)
        {
            _isFiring = true;
        }

        if (_isFiring)
        {
            UpdateFiring();
        }
    }


    private void UpdateFiring()
    {
        if (Time.time - _lastShotTime >= Interval && !Locked)
        {
            _lastShotTime = Time.time;
            Shoot();
        }
    }

    protected override void Shoot()
    {
        _animator.Play("fire@assault_rifle_01");
        PlayFireSound();
        _ammo.Shoot();
        OnShoot.Invoke();
    }

    public void FinishShooting()
    {
    }
}
