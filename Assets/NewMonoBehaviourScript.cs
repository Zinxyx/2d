using UnityEngine;

public class MonsterSmoothZMovement : MonoBehaviour
{
    public float speed = 2f;
    public float zWidth = 5f; // ������ Z
    public float zHeight = 3f; // ������ Z
    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * speed;

        // ��������������� �������� �� Z
        float x = Mathf.Lerp(-zWidth, zWidth, t % 1f);
        float y;

        if (t % 2f < 1f) // ������ ��������� (������� ����� Z)
            y = Mathf.Lerp(0, zHeight, t % 1f);
        else // ������ ��������� (������ ����� Z)
            y = Mathf.Lerp(zHeight, 0, t % 1f);

        transform.position = new Vector2(x, y);
    }
}