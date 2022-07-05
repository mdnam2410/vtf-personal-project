using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField]
    private BehaviorTree _behaviorTree;

    private SharedFloat _speed;
    private SharedFloat _fieldOfView;
    private GameObject _currentTarget;

    private void OnValidate()
    {
        _behaviorTree = GetComponent<BehaviorTree>();
    }

    private void Start()
    {
        _speed = _behaviorTree.GetVariable("Speed") as SharedFloat;
        _fieldOfView = _behaviorTree.GetVariable("FieldOfView") as SharedFloat;

        _speed.Value = 1;
        _fieldOfView.Value = 90;

        _behaviorTree.EnableBehavior();
    }

    public void OnReceivingDamage()
    {
        _behaviorTree.SendEvent("Event_ReceiveDamage");
    }

    public void OnDeath()
    {
        _behaviorTree.SendEvent("IsDead");
    }

    public GameObject CurrentTarget()
    {
        var target = _behaviorTree.GetVariable("CurrentTarget") as SharedGameObject;
        return target.Value;
    }
}
