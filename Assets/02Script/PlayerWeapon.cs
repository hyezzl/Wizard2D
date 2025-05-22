using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform fireTrans;
    [SerializeField] private float spreadAngle = 20.0f;

    private bool isFiring = false;
    private int projNum = 3;
    private float fireInterval = 0.3f;
    private float nextFireTime = 0f;
    private ProjectileManager pm;

    // ���꺯��
    float startAngle;
    float angle;
    Quaternion fireRotation;
    Vector2 fireDir;
    Vector2 lookDir = Vector2.right;

    private void Awake()
    {
        pm = FindAnyObjectByType<ProjectileManager>();
        if (pm == null) {
            Debug.Log("PlayerWeapon - ProjectileManager ��������");
        }    
    }


    public void Fire(Vector2 newDir) {
        // �⺻ ����
        // �Է��� ���� ���� ���ⰻ�� (�⺻�� : ������)
        if (newDir != Vector2.zero)
        {
            lookDir = newDir;
        }

        if (Time.time < nextFireTime) return;

        if (isFiring) {
            nextFireTime = Time.time + fireInterval;

            startAngle = -spreadAngle * (projNum - 1) / 2f;

            for (int i = 0; i < projNum; i++) {
                angle = startAngle + spreadAngle * i;

                fireRotation = fireTrans.rotation * Quaternion.Euler(0f, 0f, angle);
                
                fireDir = fireRotation * lookDir;

                pm.FireProjectile(ProjectileType.player01,
                                    fireTrans.position,
                                    fireDir,
                                    gameObject,
                                    1,
                                    10f);
            }

        }
    }


    public void SetOwner()
    {
    }

    public void SetEnable(bool newEnable)
    {
        isFiring = newEnable;
    }
}
