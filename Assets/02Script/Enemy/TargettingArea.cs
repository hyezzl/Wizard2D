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
        if (collision.gameObject == transform.parent.gameObject) return;
        if (collision.CompareTag("Player"))
        {
            transform.parent.GetComponent<Enemy>().IsTarget = true;
            Debug.Log("ÇÃ·¹ÀÌ¾î Å¸°ÙÆÃ ON");
        }
        else
            Debug.Log($"TargettingArea ¿Í {collision.name} °¡ ºÎµúÈû");
    }
}
