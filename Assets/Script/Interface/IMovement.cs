using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move(Vector2 dir);

    void SetDir(int key);

    void SetEnable(bool newEnable);
}
