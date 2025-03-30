using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // Урон, наносимый пулей (можно задать в префабе)

    void OnTriggerEnter2D(Collider2D other)
    {
        // Пытаемся получить компонент EnemyHealth у объекта, с которым столкнулась пуля
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        // Если у объекта есть компонент EnemyHealth, наносим ему урон
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject); // Уничтожаем пулю после нанесения урона
        }
        else
        {
            //Если не попали во врага
            Destroy(gameObject); // Всё равно уничтожаем пулю
        }
    }
}
