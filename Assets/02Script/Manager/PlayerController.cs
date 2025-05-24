using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 소유한 여러기능을 모두 컨트롤
public class PlayerController : MonoBehaviour, IObjectControl
{
    private IMovement movement;
    private IWeapon curWeapon;
    private IDash dash;
    private Vector2 inputDir;

    private void Awake()
    {
        if (!TryGetComponent<IMovement>(out movement)) {
            Debug.Log("PlayerController.cs - movement 참조 실패");
        }
        if (!TryGetComponent<IWeapon>(out curWeapon)) {
            Debug.Log("PlayerController.cs - IWeapon 참조 실패");
        }
        if (!TryGetComponent<IDash>(out dash)) {
            Debug.Log("PlayerController.cs - IDash 참조 실패");
        }
    }

    public void RestartGame()
    {
        movement?.SetEnable(true);
        curWeapon?.SetEnable(true);
    }

    public void ResumeGame()
    {
        movement?.SetEnable(true);
        curWeapon?.SetEnable(true);
    }

    public void StartGame()
    {
        movement?.SetEnable(true);
        curWeapon?.SetEnable(true);
    }

    public void StopGame()
    {
        movement?.SetEnable(false);
        curWeapon?.SetEnable(false);
    }

    public void UpdateGame(Vector2 newDir)
    {
        inputDir = newDir;
        if (Input.GetKeyDown(KeyCode.Space)) {
            dash?.StartDash(newDir);
        }
        curWeapon?.Fire(newDir);
        curWeapon?.ExtraFire(newDir);
    }

    public void FixedUpdateGame(Vector2 newDir)
    {
        movement?.Move(newDir);
        dash?.Dash(newDir);
    }

    public void DirUpdate(int key)
    {
        movement?.SetDir(key);
    }
}
