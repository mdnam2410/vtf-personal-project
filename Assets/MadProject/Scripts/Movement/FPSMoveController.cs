using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FPSMoveController : MonoBehaviour
{
    public float MoveSpeed = 3;
    public float RunSpeed = 6;
    public UnityEvent OnWalking;
    public UnityEvent OnStopWalking;
    public UnityEvent OnRunning;
    public UnityEvent OnStopRunning;

    [SerializeField]
    private CharacterController _characterController;

    private void OnValidate()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateMove();
    }

    private void UpdateMove()
    {
        float xInput = Input.GetAxis("Vertical");
        float yInput = Input.GetAxis("Horizontal");
        Vector3 direction = xInput * transform.forward + yInput * transform.right;

        var speed = Input.GetKey("left shift") ? RunSpeed : MoveSpeed;
        Vector3 velocity = speed * direction;

        InvokeEvents(isMoving: direction != Vector3.zero, isRunning: speed == RunSpeed);
        _characterController.SimpleMove(velocity);
    }

    private void InvokeEvents(bool isMoving, bool isRunning)
    {
        if (!isMoving)
        {
            OnStopWalking.Invoke();
            OnStopRunning.Invoke();
            return;
        }

        if (isRunning)
        {
            OnRunning.Invoke();
            OnStopWalking.Invoke();
        }
        else
        {
            OnWalking.Invoke();
            OnStopRunning.Invoke();
        }
    }
}
