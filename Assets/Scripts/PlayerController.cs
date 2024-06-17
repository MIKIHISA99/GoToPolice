using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;       // Скорость движения вперед
    public float turnSpeed = 50f;   // Скорость поворота
    private LevelController lvlController;

    private void Start()
    {
        lvlController = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        if (lvlController.inGame)
        {
            // Движение вперед
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Поворот влево и вправо
            float turn = 0f;
            if (Input.GetKey(KeyCode.A))
            {
                turn = -1f; // Влево
            }
            else if (Input.GetKey(KeyCode.D))
            {
                turn = 1f; // Вправо
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
