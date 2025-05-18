using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private void Awake()
    {
        if (TryGetComponent<CircleCollider2D>(out CircleCollider2D col)) {
            col.radius = 0.1f;
            col.isTrigger = true;
        }

        if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rig)) {
            rig.gravityScale = 0f;
        }
    }
}
