using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzleFlash;
    [SerializeField]
    private GameObject _flashLight;
    [SerializeField]
    private float _duration = 0.1f;

    private float _lastShowTime;

    private void OnEnable()
    {
        Hide();
    }

    public void Flash()
    {
        Show();
        Invoke(nameof(Hide), _duration);
    }

    private void Show()
    {
        _muzzleFlash.gameObject.SetActive(true);
        _flashLight.SetActive(true);
    }

    private void Hide()
    {
        _muzzleFlash.gameObject.SetActive(false);
        _flashLight.SetActive(false);
    }
}
