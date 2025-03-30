using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость движения
    public float boundaryLeft = -5f; // Левая граница
    public float boundaryRight = 5f; // Правая граница
    public bool reverseDirection = false;

    private int direction = 1; // 1 - вправо, -1 - влево
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Сохраняем начальную позицию
        direction = reverseDirection ? -1 : 1;
    }

    void Update()
    {
        // Вычисляем движение
        float moveAmount = moveSpeed * Time.deltaTime * direction;
        // Перемещаем объект
        transform.Translate(Vector3.right * moveAmount);

        // Проверяем границы
        if (transform.position.x > boundaryRight)
        {
            transform.position = new Vector3(boundaryRight, transform.position.y, transform.position.z);
            direction = -1; // Меняем направление
        }
        else if (transform.position.x < boundaryLeft)
        {
            transform.position = new Vector3(boundaryLeft, transform.position.y, transform.position.z);
            direction = 1; // Меняем направление
        }
    }
}
