using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 소유한 여러기능을 모두 컨트롤
public class PlayerController : MonoBehaviour, IObjectControl
{
    private IMovement movement;
    private IWeapon curWeapon;

    private void Awake()
    {
        if (!TryGetComponent<IMovement>(out movement)) {
            Debug.Log("PlayerController.cs - movement 참조 실패");
        }
        if (!TryGetComponent<IWeapon>(out curWeapon)) {
            Debug.Log("PlayerController.cs - curWeapon 참조 실패");
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            movement?.StartDash(newDir);
        }
        curWeapon?.Fire(newDir);
    }

    public void FixedUpdateGame(Vector2 newDir)
    {
        movement?.Move(newDir);
        movement?.Dash(newDir);
    }

    public void DirUpdate(int key)
    {
        movement?.SetDir(key);
    }
}
