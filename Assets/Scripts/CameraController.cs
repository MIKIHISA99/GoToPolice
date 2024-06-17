using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // ������ �� ��������� ������
    public Vector3 offset; // ��������� �������� �� ������
    public float followSpeed = 5f; // �������� ����������

    void Start()
    {
        if (player == null)
        {
            return;
        }

        // ��������� ��������� �������� �� ������
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            return; // ���� ����� �� ��������, ������ �� ������
        }

        // ������� ������� ������
        Vector3 targetPosition = player.position + offset;

        // ������� ����������� ������ � ������� �������
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
