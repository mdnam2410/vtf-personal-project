using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T s_instance;
    public static T Instance
    {
        get
        {
            if (s_instance == null)
            {
                AssignSingleton(FindObjectOfType<T>());
            }

            return s_instance;
        }
        private set {}
    }

    private void Awake()
    {
        if (s_instance == null)
        {
            AssignSingleton((T) (MonoBehaviour) this);
        }
        else if (s_instance != this)
        {
            Destroy(gameObject);
        }
    }

    static void AssignSingleton(T instance)
    {
        s_instance = instance;
        DontDestroyOnLoad(s_instance);
    }
}
