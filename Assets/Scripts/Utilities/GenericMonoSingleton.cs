using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance { get => instance; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
