using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
    public Vector2 GetInput();

    public int GetDir();
}
