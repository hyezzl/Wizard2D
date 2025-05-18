using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour, IMovement
{
    private bool isMoving = false;
    private bool isDashing = false;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float dashPower = 10.0f;
    [SerializeField] private float dashDuration = 0.18f;
    private Vector3 destination = Vector3.zero;
    private Vector2 lookDir = Vector2.right;
    private Rigidbody2D rig; 
    private float dashTimer = 0f;

    private Animator anim;

    private void Awake()
    {
        if (TryGetComponent<Rigidbody2D>(out rig)) {
            rig.gravityScale = 0f;
        }
        if (!TryGetComponent<Animator>(out anim)) {
            Debug.Log("PlayerMove - amim 참조실패");
        }
    }


    public void Move(Vector2 dir)
    {
        if (isDashing || !isMoving) return;


        rig.velocity = dir.normalized * moveSpeed;  // 움직이는게 번져보여 ..

        //if (isMoving) {
        //    // ★ transform.position 은 Vector3구조체로, x/y/z 각자 값만 변경할 수 없음!
        //    //      임시변수에 현재위치를 저장하고, 값을 변경한 뒤 다시 할당해주는 식!
        //    destination.x += dir.x * (moveSpeed * Time.deltaTime);
        //    destination.y += dir.y * (moveSpeed * Time.deltaTime);
        //    destination.z = 0f;
        //    transform.position = destination;
        //}
    }

    public void SetDir(int key)
    {
        // 플레이어가 향하는 방향 Set
        if (key == 1 || key == -1) {
            transform.localScale = new Vector3(key, 1f, 1f);
        }
    }

    public void StartDash(Vector2 dir) {
        if (isMoving && !isDashing && dir != Vector2.zero) {
            // Move중에만 대시 사용가능, 대시 중첩불가
            isDashing = true;
            dashTimer = 0f;

            anim.SetBool("isDashing", isDashing);
        }
    }

    // 입력은 Update 에서, 물리처리는 FixedUpdate에서 하기위해 함수 분리
    public void Dash(Vector2 dir) {
        if (isDashing) {
            dashTimer += Time.fixedDeltaTime;

            if (dir != Vector2.zero)
            {
                lookDir = dir.normalized;
            }
            rig.velocity = lookDir * dashPower;

            if (dashTimer >= dashDuration) {
                isDashing = false;
                rig.velocity = Vector2.zero;

                anim.SetBool("isDashing", isDashing);
            }

        }
    }


    public void SetEnable(bool newEnable)
    {
        isMoving = newEnable;
    }
}
