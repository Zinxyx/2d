using UnityEngine;

public class BarrierCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ���������, �������� � �������, ����������� "Hero"
        if (other.gameObject.CompareTag("Hero"))
        {
            // �������� Rigidbody2D ���������� Hero
            Rigidbody2D heroRb = other.GetComponent<Rigidbody2D>();

            if (heroRb != null)
            {
                // ������������� ������ Hero ����� ������
                // ������ 1: ������ ������������� ��������
                heroRb.linearVelocity = Vector2.zero;

                // ������ 2: ����������� Hero �����
                //Vector2 direction = (other.transform.position - transform.position).normalized;
                //heroRb.AddForce(-direction * 5f, ForceMode2D.Impulse); // ����������� � ����� 5

                Debug.Log("Hero ��������� ������ ����� ������!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Rigidbody2D heroRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (heroRb != null)
            {
                heroRb.linearVelocity = Vector2.zero;
                Debug.Log("Hero ���������� � ��������!");
            }
        }
    }
}
