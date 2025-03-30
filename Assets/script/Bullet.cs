using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // ����, ��������� ����� (����� ������ � �������)

    void OnTriggerEnter2D(Collider2D other)
    {
        // �������� �������� ��������� EnemyHealth � �������, � ������� ����������� ����
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        // ���� � ������� ���� ��������� EnemyHealth, ������� ��� ����
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject); // ���������� ���� ����� ��������� �����
        }
        else
        {
            //���� �� ������ �� �����
            Destroy(gameObject); // �� ����� ���������� ����
        }
    }
}
