using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyType { 
        Slime,

    }
    [SerializeField] private GameObject[] enemyPrefabs;

    private void Awake()
    {
        PoolManager.enemyPool = new Queue<Enemy>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++) {
            PoolManager.enemyPool[i] = new Queue<Enemy>();
        }
    }
}
