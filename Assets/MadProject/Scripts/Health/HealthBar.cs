using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health _hp;
    [SerializeField]
    private Image _barImage;
    [SerializeField]
    private Camera _camera;

    public bool isWorldSpace = true;

    private void OnValidate()
    {
        _hp = GetComponent<Health>();
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        UpdateHealthBarValue();
        if (isWorldSpace)
            LookAtCamera();
    }

    private void UpdateHealthBarValue()
    {
        float fillAmount = ((float)_hp.CurrentHP) / _hp.MaxHP;
        _barImage.fillAmount = fillAmount;
    }

    private void LookAtCamera()
    {
        _barImage.transform.LookAt(_barImage.transform.position + _camera.transform.rotation * -Vector3.back, _camera.transform.rotation * Vector3.up);
    }
}
