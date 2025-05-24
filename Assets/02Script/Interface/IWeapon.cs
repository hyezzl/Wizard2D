using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Fire(Vector2 newDir);

    void ExtraFire(Vector2 newDir);

    void SetOwner();

    void SetEnable(bool newEnable);
}
