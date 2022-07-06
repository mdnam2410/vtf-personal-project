using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP;

    public UnityEvent OnDeath;
    public UnityEvent<GameObject> OnDeathWithGameObject;

    private void OnValidate()
    {
        CurrentHP = MaxHP;
    }

    // Return true if there is HP getting reduced
    public bool ReduceHP(int amount)
    {
        if (CurrentHP == 0) return false;
        int reduceAmount = Mathf.Min(CurrentHP, amount);
        CurrentHP -= reduceAmount;
        if (CurrentHP == 0)
        {
            OnDeath.Invoke();
            OnDeathWithGameObject.Invoke(gameObject);
        }
        return true;
    }
}
