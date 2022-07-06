using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float DelayTime;

    void Start()
    {
        Destroy(gameObject, DelayTime);    
    }
}
