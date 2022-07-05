using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBehaviour : MonoBehaviour
{
    [SerializeField]
    private Ammo _ammo;
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    private AudioSource _reloadAmmoLeftSound;
    [SerializeField]
    private AudioSource _reloadOutOfAmmoSound;

    private int ReloadTrigger = Animator.StringToHash("Reload");
    private int OutOfAmmo = Animator.StringToHash("OutOfAmmo");

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
        _ammo.OnAmmoChange.AddListener(CheckOutOfAmmo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _ammo.CanReload())
        {
            _animator.SetTrigger(ReloadTrigger);
            _ammo.Reload();
        }
    }

    private void CheckOutOfAmmo()
    {
        _animator.SetBool(OutOfAmmo, _ammo.LoadedAmmo == 0);
    }

    public void PlayReloadAmmoLeft()
    {
        _reloadAmmoLeftSound.Play();
    }

    public void PlayReloadOutOfAmmo()
    {
        _reloadOutOfAmmoSound.Play();
    }
}
