using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;       // �������� �������� ������
    public float turnSpeed = 50f;   // �������� ��������
    private LevelController lvlController;

    private void Start()
    {
        lvlController = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        if (lvlController.inGame)
        {
            // �������� ������
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // ������� ����� � ������
            float turn = 0f;
            if (Input.GetKey(KeyCode.A))
            {
                turn = -1f; // �����
            }
            else if (Input.GetKey(KeyCode.D))
            {
                turn = 1f; // ������
            }
            transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Police")
            {
                Destroy(this.gameObject);
                var levelController = FindObjectOfType<LevelController>();
                if (levelController != null)
                {
                    levelController.GameOver();
                }
            }
        }
    }
}
