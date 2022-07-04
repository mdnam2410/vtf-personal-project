using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _animator.SetTrigger("Fire");
    }
}
