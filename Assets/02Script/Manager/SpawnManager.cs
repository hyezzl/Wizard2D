using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private EnemyManager em;

    private void Awake()
    {
        em = FindAnyObjectByType<EnemyManager>();
        if (em == null) {
            Debug.Log("SpawnManager.cs - EnemyManager 참조 실패");
        }
    }

    // 적 스폰시, EnemyManager의 AddEnemy함수 이용해 활성화 적 리스트에 넣어줘야함!
}
