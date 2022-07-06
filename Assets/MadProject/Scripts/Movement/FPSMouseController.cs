using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPSMouseController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private float _mouseSensitivity = 0.001f;
    [SerializeField]
    private Transform _cameraHolder;
    [SerializeField]
    private float _minPitch = -60;
    [SerializeField]
    private float _maxPitch = 60;
    [SerializeField]
    private float _smoothFactor = 5f;
    [SerializeField]
    private float _touchSensitivity = 8f;

    private bool _isRotating;
    private Vector2 _startTouchPosition;

    private Vector3 _startYaw;
    private Vector3 _startPitch;
    private Vector3 _desiredYaw;
    private Vector3 _desiredPitch;
    
    private void Start()
    {
        _desiredYaw = transform.rotation.eulerAngles;
        _desiredPitch = _cameraHolder.localEulerAngles;
    }

    private void Update()
    {
        if (_isRotating)
        {
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_desiredYaw), _smoothFactor * Time.unscaledDeltaTime);
            _cameraHolder.localRotation = Quaternion.Lerp(_cameraHolder.localRotation, Quaternion.Euler(_desiredPitch), _smoothFactor * Time.unscaledDeltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        _isRotating = true;
        _startTouchPosition = pointerEventData.position;

        _startYaw = transform.rotation.eulerAngles;
        _startPitch = _cameraHolder.localEulerAngles;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        var deltaTouchPosition = (pointerEventData.position - _startTouchPosition) / Screen.dpi;
        var deltaAngle = deltaTouchPosition * _touchSensitivity;

        _desiredYaw.y = SimplifyAngle(_startYaw.y + deltaAngle.x);
        _desiredPitch.x = SimplifyAngle(_startPitch.x - deltaAngle.y);
        _desiredPitch.x = Mathf.Clamp(_desiredPitch.x, _minPitch, _maxPitch);
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        _isRotating = false;
    }

    private float SimplifyAngle(float angle)
    {
        while (angle >= 180)
        {
            angle -= 360;
        }
        while (angle <= -180)
        {
            angle += 360;
        }
        return angle;
    }
}
