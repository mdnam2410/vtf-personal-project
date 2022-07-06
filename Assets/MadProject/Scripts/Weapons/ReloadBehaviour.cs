using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Button _reloadButton;

    private int ReloadTrigger = Animator.StringToHash("Reload");
    private bool _isReloading;
    private bool _buttonPressed;

    private void OnValidate()
    {
        _shooter = GetComponent<Shooting>();
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
    }

    private void Start()
    {
        _reloadButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        if (_isReloading) return;
        if (_buttonPressed && _ammo.CanReload())
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

    private void OnClick()
    {
        _buttonPressed = true;
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
        _buttonPressed = false;
    }
}
