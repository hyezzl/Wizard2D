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

    private void Allocate(ProjectileType type) {
        // 10俺究 固府 积己
        for (int i = 0; i < 10; i++) {
            obj = Instantiate(projectilePrefabs[(int)type]);
            if (obj.TryGetComponent<Projectile>(out Projectile proj)) {
                PoolManager.objectPool["Projectile"][(int)type].Enqueue(proj);
            }
            obj.SetActive(false);
        }
    }

    // 惯荤
    public void FireProjectile(ProjectileType type,
                                Vector3 spawnPos,
                                Vector3 moveDir,
                                GameObject ownerObj,
                                int damage,
                                float moveSpeed)
    {
        proj = GetProjectile(type);
        if (proj != null)
        {
            proj.transform.position = spawnPos;
            proj.gameObject.SetActive(true);

            proj.InitProjectile(type,
                                moveDir,
                                ownerObj,
                                damage,
                                moveSpeed);
        }
    }

    private Projectile GetProjectile(ProjectileType type)
    {
        if (PoolManager.objectPool["Projectile"][(int)type].Count < 1) {
            Allocate(type);
        }
        return PoolManager.objectPool["Projectile"][(int)type].Dequeue();
    }

    public void ReturnProjectile(ProjectileType type, Projectile proj) {
        proj.gameObject.SetActive(false);
        PoolManager.objectPool["Projectile"][(int)type].Enqueue(proj);
    }
}
