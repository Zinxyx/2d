using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� ��������
    public float boundaryLeft = -5f; // ����� �������
    public float boundaryRight = 5f; // ������ �������
    public bool reverseDirection = false;

    private int direction = 1; // 1 - ������, -1 - �����
    private Vector3 startPosition;
    private bool isFacingRight = false; // ������ �� ��������� ������� �����
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPosition = transform.position;
        direction = reverseDirection ? -1 : 1;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ������������� ��������� ��������� (���� �����)
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
            direction = -1; // ���� �����
            FlipSprite(); // ��������� (� �������� ���������)
        }
        else if (transform.position.x < boundaryLeft)
        {
            transform.position = new Vector3(boundaryLeft, transform.position.y, transform.position.z);
            direction = 1; // ���� ������
            FlipSprite(); // ��������� (���������)
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = isFacingRight; // ������ flipX = true ��� �������� ������
        }
        else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * (isFacingRight ? 1 : -1);
            transform.localScale = newScale;
        }
    }
}