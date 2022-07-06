using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Shooting _shooter;
    [SerializeField]
    private int _magazineSize;
    [SerializeField]
    private int _maxAmmo;

    private int OutOfAmmo = Animator.StringToHash("OutOfAmmo");

    [field:SerializeField]
    public int LoadedAmmo { get; private set; }
    [field:SerializeField]
    public int RemainingAmmo { get; private set; }
    public UnityEvent OnAmmoChange;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _shooter = GetComponent<Shooting>();
    }

    private void Start()
    {
        LoadedAmmo = _magazineSize;
        RemainingAmmo = _maxAmmo - LoadedAmmo;
    }

    private void Update()
    {
        CheckOutOfAmmo();
    }

    private void CheckOutOfAmmo()
    {
        bool outOfAmmo = LoadedAmmo == 0;
        _animator.SetBool(OutOfAmmo, outOfAmmo);
        if (outOfAmmo)
        {
            _shooter.Lock();
        }
    }

    public bool CanReload()
    {
        return RemainingAmmo > 0;
    }

    public void Shoot()
    {
        LoadedAmmo -= 1;
        OnAmmoChange.Invoke();
    }

    public void Reload()
    {
        if (!CanReload()) return;
        int requiredAmmo = _magazineSize - LoadedAmmo;
        int addedAmmo = Mathf.Min(requiredAmmo, RemainingAmmo);

        RemainingAmmo -= addedAmmo;
        LoadedAmmo += addedAmmo;
    }
}
