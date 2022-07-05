using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaking : MonoBehaviour
{
    [SerializeField]
    private GameObject _bloodSplatterPrefab;

    public void TakeDamage(RaycastHit hitInfo, int damage)
    {
        var hp = GetComponent<HP>();
        bool notDead = hp.ReduceHP(damage);
        if (notDead)
            CreateBloodSplatter(hitInfo);
    }

    private void CreateBloodSplatter(RaycastHit hitInfo)
    {
        if (_bloodSplatterPrefab != null)
            Instantiate(_bloodSplatterPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    }
}
