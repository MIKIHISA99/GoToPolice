using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ игрока
    public Vector3 offset; // Начальное смещение от игрока
    public float followSpeed = 5f; // Скорость следования

    void Start()
    {
        if (player == null)
        {
            return;
        }

        // Вычисляем начальное смещение от игрока
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            return; // Если игрок не назначен, ничего не делаем
        }

        // Целевая позиция камеры
        Vector3 targetPosition = player.position + offset;

        // Плавное перемещение камеры к целевой позиции
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
