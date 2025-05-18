using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Fire();

    void SetOwner();

    void SetEnable(bool newEnable);
}
