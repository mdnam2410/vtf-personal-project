using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField]
    private BehaviorTree _behaviorTree;
    [SerializeField]
    private Animator _animator;

    private int PlayerLayer = 7;
    private int VictimLayer = 8;
    private SharedFloat _speed;
    private SharedFloat _fieldOfView;
    private SharedGameObjectList _targets;

    private void OnValidate()
    {
        _behaviorTree = GetComponent<BehaviorTree>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _speed = _behaviorTree.GetVariable("Speed") as SharedFloat;
        _fieldOfView = _behaviorTree.GetVariable("FieldOfView") as SharedFloat;
        _targets = _behaviorTree.GetVariable("Targets") as SharedGameObjectList;
        _targets.Value = FindTargets();
        _behaviorTree.EnableBehavior();
    }

    private List<GameObject> FindTargets()
    {
        var objects = FindObjectsOfType<GameObject>();
        if (objects == null) return null;

        List<GameObject> targets = new List<GameObject>();
        for (int i = 0; i < objects.Length; ++i)
        {
            if (objects[i].layer == PlayerLayer || objects[i].layer == VictimLayer)
            {
                targets.Add(objects[i]);
            }
        }
        return targets;
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
