using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyType { 
        slimeG,
        slimeR,
    }


    [SerializeField] private GameObject[] enemyPrefabs;
    private Enemy enemy;

    private void Awake()
    {
        PoolManager.enemyPool = new Queue<Enemy>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++) {
            PoolManager.enemyPool[i] = new Queue<Enemy>();
        }
        if (!TryGetComponent<Enemy>(out enemy)) {
            Debug.Log("EnemyManager - Enemy 참조실패");
        }
    }

    public void UpdateGame() 
    {
        enemy.SetDir(0);
    }

    public void FixedUpdateGame()
    {
        enemy.Move(Vector2.zero);
    }
}
