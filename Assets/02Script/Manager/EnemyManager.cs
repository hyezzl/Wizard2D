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
    private int spawnCnt;

    // 필드에 활성화 된 적 리스트
    public List<Enemy> activeEnemies = new List<Enemy>();


    private void Awake()
    {
        PoolManager.enemyPool = new Queue<Enemy>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++) {
            PoolManager.enemyPool[i] = new Queue<Enemy>();
        }
    }

    private GameObject obj;
    private Enemy enemy;



    // 적 오브젝트 풀
    private void Allocate(EnemyType type, int spawnCnt) {
        for (int i = 0; i < spawnCnt; i++) {
            obj = Instantiate(enemyPrefabs[(int)type]);
            if (obj.TryGetComponent<Enemy>(out Enemy enemy)) {
                PoolManager.enemyPool[(int)type].Enqueue(enemy);
            }
            obj.SetActive(false);
        }
    }

    public Enemy GetEnemy(EnemyType type, int spawnCnt) {
        if (PoolManager.enemyPool[(int)type].Count < 1) {
            Allocate(type, spawnCnt);
        }
        return PoolManager.enemyPool[(int)type].Dequeue();
    }

    public void ReturnEnemy(EnemyType type, Enemy enemy) {
        enemy.gameObject.SetActive(false);
        PoolManager.enemyPool[(int)type].Enqueue(enemy);
    }





    public void UpdateGame() 
    {
        //enemy.SetDir(0);
    }

    public void FixedUpdateGame()
    {
        //enemy.Move(Vector2.zero);
    }
}
