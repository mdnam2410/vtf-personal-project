using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HP _hp;
    [SerializeField]
    private Image _barImage;
    [SerializeField]
    private Camera _camera;

    private void OnValidate()
    {
        _hp = GetComponent<HP>();
    }

    private void Update()
    {
        UpdateHealthBarValue();
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
