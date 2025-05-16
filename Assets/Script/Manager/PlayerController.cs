using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾ ������ ��������� ��� ��Ʈ��
public class PlayerController : MonoBehaviour, IObjectControl
{
    private IMovement movement;

    private void Awake()
    {
        if (!TryGetComponent<IMovement>(out movement)) {
            Debug.Log("PlayerController.cs - movement ���� ����");
        }
    }

    public void RestartGame()
    {
        movement.SetEnable(true);
    }

    public void ResumeGame()
    {
        movement.SetEnable(true);
    }

    public void StartGame()
    {
        movement.SetEnable(true);
    }

    public void StopGame()
    {
        movement.SetEnable(false);
    }

    public void UpdateGame(Vector2 newDir)
    {
        movement?.Move(newDir);
    }

    public void DirUpdate(int key)
    {
        movement?.SetDir(key);
    }
}
