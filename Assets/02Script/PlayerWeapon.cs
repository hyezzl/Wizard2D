using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour, IWeapon
{
    [Header("Config")]
    [SerializeField] private Transform fireTrans;
    [SerializeField] private float spreadAngle = 20.0f;
    [SerializeField] private bool isOrbitting = true;

    private bool isFiring = false;
    //private bool isOrbitting = true;
    private bool isBlading = false;
    private bool projSpawned = false;
    private float fireBlockTimer = 0f; // �߻������ð�
    private int projNum = 3;
    private float nextFireTime = 0f;
    private ProjectileManager pm;
    private PlayerMove move;
    Vector2 lookDir = Vector2.right;
    Queue<Projectile> projQue;

    // > Default
    float angle_D;  // default
    float startAngle;
    Quaternion fireRotation;
    Vector2 fireDir;
    private float fireInterval = 0.3f;

    // > Orbit
    float angle_O = 0f;  // Circular
    float radius = 1f;
    float turnSpeed = 6f;   // ȸ���ӵ�
    List<Projectile> orbitProj = new List<Projectile>();
    int orbitCnt = 1; // ������ ��øȽ��

    // > Blade
    float angle_B;  // Blade


    private void Awake()
    {
        pm = FindAnyObjectByType<ProjectileManager>();
        if (pm == null) {
            Debug.Log("PlayerWeapon - ProjectileManager ��������");
        }
        if(!TryGetComponent<PlayerMove>(out move)){
            Debug.Log("PlayerWeapon - PlayerMove ��������");
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

        // �뽬���� �� �⺻ ���� ����
        if (move.isDashing) {
            fireBlockTimer = Time.time + 0.5f;
            return;
        }
        if (fireBlockTimer > Time.time)
        {
            return;
        }

        if (isFiring) {
            nextFireTime = Time.time + fireInterval;

            startAngle = -spreadAngle * (projNum - 1) / 2f;

            for (int i = 0; i < projNum; i++) {
                angle_D = startAngle + spreadAngle * i;

                fireRotation = fireTrans.rotation * Quaternion.Euler(0f, 0f, angle_D);
                
                fireDir = fireRotation * lookDir;

                pm.FireProjectile(ProjectileType.player01,
                                    fireTrans.position,
                                    fireDir,
                                    gameObject,
                                    1,
                                    10f,
                                    10);
            }

        }
    }

    public void ExtraFire(Vector2 newDir) {
        if (newDir != Vector2.zero)
        {
            lookDir = newDir;
        }
        if (isOrbitting)
        {
            if (!projSpawned)
            {
                orbitProj = GetProj(ProjectileType.player02, 4);
                Debug.Log($"�ٿϷ�. {orbitProj.Count}");
                projSpawned = true;
            }
            OrbitWeapon();
        }
        else {
            if (projSpawned) {
                // ������ƮǮ�� ����
                foreach (var proj in orbitProj) {
                    pm.ReturnProjectile(ProjectileType.player02, proj);
                }
                orbitProj.Clear(); // ����Ʈ���� ��λ���
                Debug.Log($"���ϿϷ�. {orbitProj.Count}");
                projSpawned = false;
            }
        }
        
        if (isBlading) {
            BladeWeapon(lookDir);
        }
    }

    private void OrbitWeapon() {
        // ���ѽð����� �÷��̾� ������ ���� ����ü
        angle_O += turnSpeed * Time.deltaTime;
        angle_O %= Mathf.PI * 2f;

        Vector2 center = transform.position;

        for (int i = 0; i < orbitCnt*2; i++) {
            float angle = angle_O + (Mathf.PI * 2f / (orbitCnt * 2)) * i;
            float x = center.x + radius * Mathf.Cos(angle);
            float y = center.y + radius * Mathf.Sin(angle);


            orbitProj[i].transform.position = new Vector3(x, y, 0f);
            orbitProj[i].gameObject.SetActive(true);
            orbitProj[i].InitProjectile(ProjectileType.player02,
                                Vector2.zero,
                                gameObject,
                                1,
                                10f);
        }
        
    }

    private void BladeWeapon(Vector2 newDir) { 
        // ���ѽð����� ó�� ���ư��� 3���� Į��
    }



    private List<Projectile> GetProj(ProjectileType type, int allocateCnt) {
        for (int i = 0; i < allocateCnt; i++) {
            orbitProj.Add(pm.GetProjectile(type, allocateCnt));
        }
        return orbitProj;
    }

    public void SetOwner()
    {
    }

    public void SetEnable(bool newEnable)
    {
        isFiring = newEnable;
    }
}
