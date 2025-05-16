using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovement
{
    private bool isMoving = false;
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 destination = Vector3.zero;

    public void Move(Vector2 dir)
    {
        if (isMoving) {
            // �� transform.position �� Vector3����ü��, x/y/z ���� ���� ������ �� ����!
            //      �ӽú����� ������ġ�� �����ϰ�, ���� ������ �� �ٽ� �Ҵ����ִ� ��!
            destination.x += dir.x * (moveSpeed * Time.deltaTime);
            destination.y += dir.y * (moveSpeed * Time.deltaTime);
            destination.z = 0f;

            transform.position = destination;

        }
    }

    public void SetDir(int key)
    {
        // �÷��̾ ���ϴ� ���� Set
        if (key == 1 || key == -1) {
            transform.localScale = new Vector3(key, 1f, 1f);
        }
    }


    public void SetEnable(bool newEnable)
    {
        isMoving = newEnable;
    }
}
