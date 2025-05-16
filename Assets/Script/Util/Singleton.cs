using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Inst { get; private set; }

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this as T;
            if (Inst == null)
            {
                Debug.Log("Singleton 참조실패");
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
        DoAwake();
    }

    protected virtual void DoAwake() { }
}

public class SingletonDestroy<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Inst { get; private set; }

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this as T;
            if (Inst == null)
            {
                Debug.Log("SingletonDestroy 참조실패");
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DoAwake();
    }

    protected virtual void DoAwake() { }
}
