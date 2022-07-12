using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _sensitivity = 0.01f;

    private Vector2 _startPosition;
    private Vector3 _delta;
    private bool _firstDrag = true;
    private bool _isMoving;

    private void Update()
    {
        if (!_isMoving) return;

        Vector3 direction = Vector3.zero;
        direction.x = -_delta.x;
        direction.z = -_delta.y;

        var speed = Input.GetKey("left shift") ? 3 : 6;
        Vector3 velocity = direction * speed;

        _target.GetComponent<CharacterController>().SimpleMove(velocity * _sensitivity);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_firstDrag)
        {
            _startPosition = eventData.position;
            _firstDrag = false;
        }
        _isMoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _delta = eventData.position - _startPosition;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isMoving = false;
        transform.position = _startPosition;
    }
}
