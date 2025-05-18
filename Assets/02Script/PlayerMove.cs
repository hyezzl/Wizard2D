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
            Debug.Log("PlayerMove - amim ��������");
        }
    }


    public void Move(Vector2 dir)
    {
        if (isDashing || !isMoving) return;


        rig.velocity = dir.normalized * moveSpeed;  // �����̴°� �������� ..

        //if (isMoving) {
        //    // �� transform.position �� Vector3����ü��, x/y/z ���� ���� ������ �� ����!
        //    //      �ӽú����� ������ġ�� �����ϰ�, ���� ������ �� �ٽ� �Ҵ����ִ� ��!
        //    destination.x += dir.x * (moveSpeed * Time.deltaTime);
        //    destination.y += dir.y * (moveSpeed * Time.deltaTime);
        //    destination.z = 0f;
        //    transform.position = destination;
        //}
    }

    public void SetDir(int key)
    {
        // �÷��̾ ���ϴ� ���� Set
        if (key == 1 || key == -1) {
            transform.localScale = new Vector3(key, 1f, 1f);
        }
    }

    public void StartDash(Vector2 dir) {
        if (isMoving && !isDashing && dir != Vector2.zero) {
            // Move�߿��� ��� ��밡��, ��� ��ø�Ұ�
            isDashing = true;
            dashTimer = 0f;

            anim.SetBool("isDashing", isDashing);
        }
    }

    // �Է��� Update ����, ����ó���� FixedUpdate���� �ϱ����� �Լ� �и�
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
