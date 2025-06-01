using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour, IDamaged, IMovement
{
    [SerializeField] private float moveSpeed = 3.0f;

    protected GameObject player;
    private Rigidbody2D rig;
    protected bool isTarget = false;

    // 적의 사망시점 델리게이트
    public static event Action<Enemy> OnEnemyDie;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            Debug.Log("Enemy - player 참조실패");
        }

        if (TryGetComponent<Rigidbody2D>(out rig)) {
            rig.gravityScale = 0f;
        }
        if (TryGetComponent<CircleCollider2D>(out CircleCollider2D col)) {
            col.radius = 0.35f;
            col.isTrigger = true;
        }
    }




    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile")) { 
            if(collision.TryGetComponent<ProjectileInfo>(out ProjectileInfo projInfo)){
                if (projInfo.owner == ProjectileOwner.Player) {
                    // 플레이어의 투사체가 적에게 피격
                    isTarget = true;
                }
            }
        }
    }




    public virtual void TakeDamage(GameObject Attacker, int Damage)
    {
        // 공통피격
    }

    public void Move(Vector2 dir)
    {
        if (isTarget) {
            Vector2 toTarget = (player.transform.position - this.transform.position).normalized;
            rig.velocity = toTarget * (moveSpeed * Time.deltaTime);
        }
    }



    public void SetDir(int key)
    {
        if (isTarget)
        {
            // 플레이어를 바라보는 방향에 따라 스프라이트 방향전환
            Vector2 toTarget = player.transform.position - this.transform.position;
            if (toTarget.x >= 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void SetEnable(bool newEnable)
    {

    }
}

