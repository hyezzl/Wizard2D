using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IMovement
{
    private float moveSpeed = 3f;
    private int damage;
    private Vector2 moveDir;
    private GameObject owner;
    private string ownerTag;
    private bool isInit = false;
    private ProjectileType type;
    private Rigidbody2D rig;
    private ProjectileManager pm;


    private void Awake()
    {
        if (TryGetComponent<CircleCollider2D>(out CircleCollider2D col)) {
            col.radius = 0.1f;
            col.isTrigger = true;
        }

        if (TryGetComponent<Rigidbody2D>(out rig)) {
            rig.gravityScale = 0f;
        }

        pm = FindAnyObjectByType<ProjectileManager>();
        if (pm == null) {
            Debug.Log("Projectile - ProjectileManager 참조실패");
        }
    }


    public void Move(Vector2 dir)
    {
        if (isInit) {
            rig.velocity = dir * moveSpeed;
        }
    }


    public void SetEnable(bool newEnable)
    {
        isInit = newEnable;
    }

    public void InitProjectile(ProjectileType newType,
                                Vector2 newDir,
                                GameObject newOwner,
                                int newDamage,
                                float newSpeed)
    {
        type = newType;
        moveDir = newDir;
        damage = newDamage;
        moveSpeed = newSpeed;
        owner = newOwner;
        ownerTag = newOwner.tag;

        SetEnable(true);
        Move(moveDir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owner) return;

        if (collision.CompareTag(ownerTag)) return;

        if (collision.CompareTag("DestroyArea"))
        {
            pm.ReturnProjectile(type, this);
        }
        else {
            // todo : 데미지 구현

            pm.ReturnProjectile(type, this);
        }
    }







    public void Dash(Vector2 dir)
    {
    }
    public void StartDash(Vector2 dir)
    {
    }
    public void SetDir(int key)
    {
    }

}
