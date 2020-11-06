using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例MonoBehaviour的模板类。将需要成为单例的类继承本类
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    private static volatile T instance;
    private static object syncRoot = new Object();
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        T[] instances = FindObjectsOfType<T>();
                        if (instances != null)
                        {
                            for (var i = 0; i < instances.Length; i++)
                            {
                                Destroy(instances[i].gameObject);
                            }
                        }
                        GameObject go = new GameObject();
                        go.name = typeof(T).Name;
                        instance = go.AddComponent<T>();
                        DontDestroyOnLoad(go);
                    }
                }
            }
            return instance;
        }
    }
}

