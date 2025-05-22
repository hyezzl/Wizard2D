using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolLabel : MonoBehaviour
{
    protected ObjectPool MyOwner;

    public virtual void SetOwner(ObjectPool newOwner) {
        MyOwner = newOwner;
        gameObject.SetActive(false);
    }
}
