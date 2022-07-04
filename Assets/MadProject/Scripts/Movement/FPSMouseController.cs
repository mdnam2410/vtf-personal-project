using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseController : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 1;
    [SerializeField]
    private Transform _cameraHolder;
    [SerializeField]
    private float _minPitch = -60;
    [SerializeField]
    private float _maxPitch = 60;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float mouseDeltaX = Input.GetAxisRaw("Mouse X");
        float yawAngle = mouseDeltaX * _mouseSensitivity;
        transform.Rotate(0, yawAngle, 0);
    }

    private void UpdatePitch()
    {
        float mouseDeltaY = Input.GetAxisRaw("Mouse Y");
        float pitchAngle = -mouseDeltaY * _mouseSensitivity;
        _cameraHolder.Rotate(pitchAngle, 0, 0);
        ClampPitchAngle();
    }

    private void ClampPitchAngle()
    {
        Vector3 pitchAngle = _cameraHolder.localEulerAngles;
        while (pitchAngle.x > 180)
        {
            pitchAngle.x -= 360;
        }

        while (pitchAngle.x < -180)
        {
            pitchAngle.x += 360;
        }
        pitchAngle.x = Mathf.Clamp(pitchAngle.x, _minPitch, _maxPitch);
        _cameraHolder.localEulerAngles = pitchAngle;
    }
}
