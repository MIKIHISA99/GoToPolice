using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarController : MonoBehaviour
{
    public Transform player;       // Ссылка на игрока
    public float speed = 10f;      // Скорость движения вперед
    public float turnSpeed = 5f;   // Скорость поворота

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    void Update()
    {
        // Проверка на наличие игрока
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

        // Направление к игроку
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Поворот к игроку
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

        // Движение вперед
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Police")
            {
                var levelContrl = FindObjectOfType<LevelController>();
                if (levelContrl != null)
                {
                    levelContrl.DestroyCarPolice(this.transform.position);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
