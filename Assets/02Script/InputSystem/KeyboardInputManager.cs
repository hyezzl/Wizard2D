using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : MonoBehaviour, IInputHandler
{
    public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public int GetDir() {
        if (Input.GetKey(KeyCode.RightArrow)) return 1;
        if (Input.GetKey(KeyCode.LeftArrow)) return -1;
        return 0;
    }

}
