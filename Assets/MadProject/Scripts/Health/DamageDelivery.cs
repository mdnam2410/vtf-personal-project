using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDelivery : MonoBehaviour
{
    [SerializeField]
    private Transform _aimingCamera;
    [SerializeField]
    private GameObject _hitEffectPrefab;
    [SerializeField]
    private int _damage;

    private const int ZombieLayer = 6;

    public void OnShoot()
    {
        PerformRaycasting();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(_aimingCamera.position, _aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo))
        {
            InspectHitInfo(hitInfo);
            CreateHitEffect(hitInfo);
        }
    }

    private void InspectHitInfo(RaycastHit hitInfo)
    {
        GameObject hitGameObject = hitInfo.collider.gameObject;
        if (hitGameObject.layer == ZombieLayer)
        {
            hitGameObject.GetComponent<DamageTaking>().TakeDamage(hitInfo, _damage);
        }
    }

    private void CreateHitEffect(RaycastHit hitInfo)
    {
        if (_hitEffectPrefab != null)
            Instantiate(_hitEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    }
}
