using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageTaking : MonoBehaviour
{
    [SerializeField]
    private GameObject _bloodSplatterPrefab;

    public UnityEvent OnReceivingDamage;

    public void TakeDamage(int damage)
    {
        var hp = GetComponent<HP>();
        if (hp == null) return;

        if (hp.ReduceHP(damage))
        {
            OnReceivingDamage.Invoke();
        }
    }

    public void TakeDamage(RaycastHit hitInfo, int damage)
    {
        var hp = GetComponent<HP>();
        bool notDead = hp.ReduceHP(damage);
        if (notDead)
        {
            CreateBloodSplatter(hitInfo);
            OnReceivingDamage.Invoke();
        }
    }

    private void CreateBloodSplatter(RaycastHit hitInfo)
    {
        if (_bloodSplatterPrefab != null)
            Instantiate(_bloodSplatterPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    }
}
