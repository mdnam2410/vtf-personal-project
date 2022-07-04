using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBehaviour : GunBehaviour
{
    [SerializeField]
    private Ammo _ammo;

    private int ReloadTrigger = Animator.StringToHash("Reload");
    private int OutOfAmmo = Animator.StringToHash("OutOfAmmo");

    private void OnValidate()
    {
        _ammo = GetComponent<Ammo>();
        _ammo.OnAmmoChange.AddListener(CheckOutOfAmmo);
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.R) && _ammo.CanReload())
        {
            _animator.SetTrigger(ReloadTrigger);
            _ammo.OnReload();
        }
    }

    private void CheckOutOfAmmo()
    {
        _animator.SetBool(OutOfAmmo, _ammo.LoadedAmmo == 0);
    }
}
