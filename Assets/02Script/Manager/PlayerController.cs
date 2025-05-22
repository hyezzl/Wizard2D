using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ������ ��������� ��� ��Ʈ��
public class PlayerController : MonoBehaviour, IObjectControl
{
    private IMovement movement;
    private IWeapon curWeapon;

    private void Awake()
    {
        if (!TryGetComponent<IMovement>(out movement)) {
            Debug.Log("PlayerController.cs - movement ���� ����");
        }
        if (!TryGetComponent<IWeapon>(out curWeapon)) {
            Debug.Log("PlayerController.cs - curWeapon ���� ����");
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
