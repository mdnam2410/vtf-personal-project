using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticFireBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Ammo _ammo;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _ammo = GetComponent<Ammo>();
    }
}
