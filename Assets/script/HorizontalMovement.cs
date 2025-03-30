using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // �������� ��������
    public float boundaryLeft = -5f; // ����� �������
    public float boundaryRight = 5f; // ������ �������
    public bool reverseDirection = false;

    private int direction = 1; // 1 - ������, -1 - �����
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // ��������� ��������� �������
        direction = reverseDirection ? -1 : 1;
    }

    void Update()
    {
        // ��������� ��������
        float moveAmount = moveSpeed * Time.deltaTime * direction;
        // ���������� ������
        transform.Translate(Vector3.right * moveAmount);

        // ��������� �������
        if (transform.position.x > boundaryRight)
        {
            transform.position = new Vector3(boundaryRight, transform.position.y, transform.position.z);
            direction = -1; // ������ �����������
        }
        else if (transform.position.x < boundaryLeft)
        {
            transform.position = new Vector3(boundaryLeft, transform.position.y, transform.position.z);
            direction = 1; // ������ �����������
        }
    }
}
