using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyManager;

public enum PoolType { 
    projectile,
    enemy
}

public class PoolManager : SingletonDestroy<PoolManager>
{
    public static Queue<Projectile>[] projectilePool;
    public static Queue<Enemy>[] enemyPool;
    
    //int projNum = System.Enum.GetValues(typeof(ProjectileType)).Length;
    //int enemyNum = System.Enum.GetValues(typeof(EnemyType)).Length;

    protected override void DoAwake()
    {
        //projectilePool = new Queue<Projectile>[projNum];
        //enemyPool = new Queue<Enemy>[enemyNum];
    }
}
