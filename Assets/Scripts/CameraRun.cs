using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRun : MonoBehaviour
{
    public Transform target; // ������� ������, �� ������� ������� ������
    public float leftOffset = -4f; // �������� ����� ������������ ������� �������

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x - leftOffset, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}

