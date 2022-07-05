using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    private int _damage;

    public void DeliverDamage()
    {
        GameObject target = GetComponent<ZombieAI>().CurrentTarget();
        Debug.Log(target);
        if (target == null) return;

        DamageTaking damageTaking = target.GetComponent<DamageTaking>();
        damageTaking?.TakeDamage(_damage);
    }
}
