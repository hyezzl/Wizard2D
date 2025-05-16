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
            // ★ transform.position 은 Vector3구조체로, x/y/z 각자 값만 변경할 수 없음!
            //      임시변수에 현재위치를 저장하고, 값을 변경한 뒤 다시 할당해주는 식!
            destination.x += dir.x * (moveSpeed * Time.deltaTime);
            destination.y += dir.y * (moveSpeed * Time.deltaTime);
            destination.z = 0f;

            transform.position = destination;

        }
    }

    public void SetDir(int key)
    {
        // 플레이어가 향하는 방향 Set
        if (key == 1 || key == -1) {
            transform.localScale = new Vector3(key, 1f, 1f);
        }
    }


    public void SetEnable(bool newEnable)
    {
        isMoving = newEnable;
    }
}
