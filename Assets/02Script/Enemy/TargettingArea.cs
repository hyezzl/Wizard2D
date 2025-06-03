using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargettingArea : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rig)) {
            rig.gravityScale = 0f;
            rig.isKinematic = true;
        }
        if (TryGetComponent<CircleCollider2D>(out CircleCollider2D col)) {
            col.isTrigger = true;
            col.radius = 1.8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = transform.parent.GetComponent<Enemy>();
        if (collision.gameObject == transform.parent.gameObject) return;
        if (collision.CompareTag("Player") && enemy.IsTarget == false)
        {
            enemy.IsTarget = true;
            Debug.Log("플레이어 타겟팅 ON");
        }
        else
            // 타겟팅 후 부딪혀도 여기 분기문
            Debug.Log($"TargettingArea 와 {collision.name} 가 부딪힘");
    }
}
