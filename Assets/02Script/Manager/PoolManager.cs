using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonDestroy<PoolManager>
{
    public static Dictionary<string, Queue<Projectile>[]> objectPool;

    protected override void DoAwake()
    {
        objectPool = new Dictionary<string, Queue<Projectile>[]>();
    }
}
