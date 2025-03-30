using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Скорость движения
    public float boundaryLeft = -5f; // Левая граница
    public float boundaryRight = 5f; // Правая граница
    public bool reverseDirection = false;

    private int direction = 1; // 1 - вправо, -1 - влево
    private Vector3 startPosition;
    private bool isFacingRight = false; // Теперь по умолчанию смотрит влево
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPosition = transform.position;
        direction = reverseDirection ? -1 : 1;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Устанавливаем начальное отражение (если нужно)
        if (!isFacingRight)
        {
            FlipSprite();
        }
    }

    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime * direction;
        transform.Translate(Vector3.right * moveAmount);

        if (transform.position.x > boundaryRight)
        {
            transform.position = new Vector3(boundaryRight, transform.position.y, transform.position.z);
            direction = -1; // Идем влево
            FlipSprite(); // Переворот (в исходное состояние)
        }
        else if (transform.position.x < boundaryLeft)
        {
            transform.position = new Vector3(boundaryLeft, transform.position.y, transform.position.z);
            direction = 1; // Идем вправо
            FlipSprite(); // Переворот (зеркально)
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = isFacingRight; // Теперь flipX = true при движении вправо
        }
        else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * (isFacingRight ? 1 : -1);
            transform.localScale = newScale;
        }
    }
}