using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireBehaviour : GunBehaviour
{
    //[SerializeField]
    //private Animator _animator;

    [SerializeField]
    private Ammo _ammo;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_ammo.LoadedAmmo == 0) return;
        _animator.SetTrigger("Fire");
        _ammo.OnShoot();
    }
}
