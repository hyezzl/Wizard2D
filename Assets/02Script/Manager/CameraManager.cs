using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // ������Ʈ�� �÷��̾�� ��Ź
    private GameObject player;


    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void LateUpdate()
    {
        Debug.Log("dd'");
        Vector3 targetPos = new Vector3(player.transform.position.x,
                                        player.transform.position.y,
                                        -10f);

        //transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        transform.position = targetPos;
    }
}
