using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ProjectileType { 
    player01,
    player02,
    player03,
    player04,
}

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectilePrefabs;
    private int allocateCnt;

    private void Awake()
    {
        PoolManager.objectPool["Projectile"] = new Queue<Projectile>[projectilePrefabs.Length];
        for (int i = 0; i < projectilePrefabs.Length; i++)
        {
            PoolManager.objectPool["Projectile"][i] = new Queue<Projectile>();
        }
    }

    private GameObject obj;
    private Projectile proj;

    private void Allocate(ProjectileType type, int allocateCnt) {
        // 10개씩 미리 생성
        for (int i = 0; i < allocateCnt; i++) {
            obj = Instantiate(projectilePrefabs[(int)type]);
            if (obj.TryGetComponent<Projectile>(out Projectile proj)) {
                PoolManager.objectPool["Projectile"][(int)type].Enqueue(proj);
            }
            obj.SetActive(false);
        }
    }

    // 발사
    public void FireProjectile(ProjectileType type,
                                Vector3 spawnPos,
                                Vector3 moveDir,
                                GameObject ownerObj,
                                int damage,
                                float moveSpeed,
                                int allocateCnt)
    {
        proj = GetProjectile(type, allocateCnt);
        if (proj != null)
        {
            // 타입따라 다르게?
            proj.transform.position = spawnPos;
            proj.gameObject.SetActive(true);

            proj.InitProjectile(type,
                                moveDir,
                                ownerObj,
                                damage,
                                moveSpeed);
        }
    }

    public Projectile GetProjectile(ProjectileType type, int allocateCnt)
    {
        if (PoolManager.objectPool["Projectile"][(int)type].Count < 1) {
            Allocate(type, allocateCnt);
        }
        return PoolManager.objectPool["Projectile"][(int)type].Dequeue();
    }

    public void ReturnProjectile(ProjectileType type, Projectile proj) {
        proj.gameObject.SetActive(false);
        PoolManager.objectPool["Projectile"][(int)type].Enqueue(proj);
    }
}
