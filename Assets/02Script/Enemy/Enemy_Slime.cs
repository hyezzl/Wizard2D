using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{




    public override void TakeDamage(GameObject Attacker, int Damage)
    {
        base.TakeDamage(Attacker, Damage);
    }

    protected override void OnTriggerEnter2D(Collider2D collision) { 
        base.OnTriggerEnter2D(collision);
        
    }
}
