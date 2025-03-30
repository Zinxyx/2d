using UnityEngine;

public class MonsterSmoothZMovement : MonoBehaviour
{
    public float speed = 2f;
    public float zWidth = 5f; // Ўирина Z
    public float zHeight = 3f; // ¬ысота Z
    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * speed;

        // ѕараметрическое движение по Z
        float x = Mathf.Lerp(-zWidth, zWidth, t % 1f);
        float y;

        if (t % 2f < 1f) // ѕерва€ диагональ (верхн€€ часть Z)
            y = Mathf.Lerp(0, zHeight, t % 1f);
        else // ¬тора€ диагональ (нижн€€ часть Z)
            y = Mathf.Lerp(zHeight, 0, t % 1f);

        transform.position = new Vector2(x, y);
    }
}