using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomaticFireBehaviour : Shooting
{
    private bool _isShooting;

    private void Update()
    {
        if (_isShooting) return;
        if (Input.GetButtonDown("Fire1") && !Locked)
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
        _isShooting = true;
        base.Shoot();
    }

    public void FinishShooting()
    {
        Debug.Log("Finished shooting");
        _isShooting = false;
    }
}
