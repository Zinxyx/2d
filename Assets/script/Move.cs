using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float acceleration = 50f;
    public float deceleration = 50f;
    public float maxSpeed = 5f;

    private Vector2 moveVector;
    private Vector2 currentVelocity;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on this object!");
            enabled = false;
        }
    }

    void Update()
    {
        // Получаем ввод
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Создаем вектор направления движения (нормализованный)
        moveVector = new Vector2(horizontalInput, verticalInput).normalized;

        // Зеркальное отображение
        if (horizontalInput < 0) // Движение влево
        {
            spriteRenderer.flipX = true; // Зеркалим по X
        }
        else if (horizontalInput > 0) // Движение вправо
        {
            spriteRenderer.flipX = false; // Отменяем зеркальное отображение
        }
    }

    void FixedUpdate()
    {
        // Вычисляем целевую скорость
        Vector2 targetVelocity = moveVector * maxSpeed;

        // Вычисляем разницу между текущей и целевой скоростью
        Vector2 velocityChange = targetVelocity - currentVelocity;

        // Вычисляем ускорение/замедление
        float accelerationRate = (moveVector.magnitude > 0) ? acceleration : deceleration; // Ускоряемся, если есть ввод, замедляемся, если нет

        // Применяем ускорение/замедление
        currentVelocity += velocityChange * accelerationRate * Time.fixedDeltaTime;

        // Ограничиваем скорость
        currentVelocity = Vector2.ClampMagnitude(currentVelocity, maxSpeed);

        // Перемещаем Rigidbody2D
        rb.linearVelocity = currentVelocity; // Используем velocity вместо MovePosition
    }
}