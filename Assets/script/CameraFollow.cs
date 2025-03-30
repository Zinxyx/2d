using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // Ссылка на персонажа (перетащите его из иерархии)
    public float smoothTime = 0.3f; // Время сглаживания движения камеры
    public Vector3 offset; // Смещение камеры от персонажа

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // Вычисляем желаемую позицию камеры
            Vector3 targetPosition = target.position + offset;

            // Плавное перемещение камеры к желаемой позиции
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}