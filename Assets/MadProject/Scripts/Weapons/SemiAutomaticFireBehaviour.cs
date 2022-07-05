using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SemiAutomaticFireBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Ammo _ammo;
    [SerializeField]
    private AudioSource _fireSound;

    public UnityEvent OnShoot;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
    }

    private void Update()
    {
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
        OnShoot.Invoke();
    }

    public void PlayFireSound()
    {
        _fireSound.Play();
    }
}
