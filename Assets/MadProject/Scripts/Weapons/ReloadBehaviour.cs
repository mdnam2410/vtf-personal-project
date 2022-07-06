using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBehaviour : MonoBehaviour
{
    [SerializeField]
    private Shooting _shooter;
    [SerializeField]
    private Ammo _ammo;
    [SerializeField]
    protected Animator _animator;
    [SerializeField]
    private AudioSource _reloadAmmoLeftSound;
    [SerializeField]
    private AudioSource _reloadOutOfAmmoSound;

    private int ReloadTrigger = Animator.StringToHash("Reload");
    private bool _isReloading;

    private void OnValidate()
    {
        _shooter = GetComponent<Shooting>();
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
    }

    private void Update()
    {
        if (_isReloading) return;
        if (Input.GetKeyDown(KeyCode.R) && _ammo.CanReload())
        {
            Reload();
        }
    }

    private void Reload()
    {
        _animator.SetTrigger(ReloadTrigger);
        _isReloading = true;
        _shooter.Lock();
        _ammo.Reload();
    }

    public void PlayReloadAmmoLeft()
    {
        _reloadAmmoLeftSound.Play();
    }

    public void PlayReloadOutOfAmmo()
    {
        _reloadOutOfAmmoSound.Play();
    }

    public void FinishReloading()
    {
        Debug.Log("Finished reloading");
        _isReloading = false;
        _shooter.Unlock();
    }
}
