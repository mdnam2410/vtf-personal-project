using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int _magazineSize;
    [SerializeField]
    private int _maxAmmo;

    [field:SerializeField]
    public int LoadedAmmo { get; private set; }
    [field:SerializeField]
    public int RemainingAmmo { get; private set; }

    public UnityEvent OnAmmoChange;

    private void Start()
    {
        LoadedAmmo = _magazineSize;
        RemainingAmmo = _maxAmmo - LoadedAmmo;
    }

    public bool CanReload()
    {
        return RemainingAmmo > 0;
    }

    public void OnShoot()
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
