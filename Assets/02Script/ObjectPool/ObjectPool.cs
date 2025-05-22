using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ӽ�!!!!!!!!!!!!!!!!!!!!
public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PoolLabel poolobj;

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();
    private int allocateCnt;
    private GameObject obj;
    private PoolLabel label;


    // ������Ʈ �̸� ����
    public void Allocate() {
        for (int i = 0; i < allocateCnt; i++) {
            label = Instantiate(poolobj, this.transform);
            label.SetOwner(this);
            poolStack.Push(label);
        }
    }

    // �ʿ��� �� �������� �Լ�
    public GameObject PopObject() {
        if (poolStack.Count < 1) {
            Allocate();
        }
        label = poolStack.Pop();
        label.gameObject.SetActive(true);
        return label.gameObject;
    }

    public void ReturnObject(PoolLabel returnObj) {
        returnObj.gameObject.SetActive(false);
        poolStack.Push(returnObj);
    }
}
