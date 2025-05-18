using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PoolLabel poolobj;

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();
    private int allocateCnt;
    private GameObject obj;
    private PoolLabel label;


    // 오브젝트 미리 생성
    public void Allocate() {
        for (int i = 0; i < allocateCnt; i++) {
            label = Instantiate(poolobj, this.transform);
            //
            poolStack.Push(label);
        }
    }

    // 필요할 때 꺼내쓰는 함수
}
