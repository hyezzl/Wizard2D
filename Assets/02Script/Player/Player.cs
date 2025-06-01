using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private void Awake()
    {
        if (TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D col)) {
            col.size = new Vector2(0.45f, 0.8f);
        }
    }
}
