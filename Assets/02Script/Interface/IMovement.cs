using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move(Vector2 dir);

    void SetDir(int key);

    void StartDash(Vector2 dir);   

    void Dash(Vector2 dir);

    void SetEnable(bool newEnable);
}
