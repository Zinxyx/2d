using UnityEngine;

public class Shooting : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public string name; // Название оружия
        public GameObject bulletPrefab;
        public float bulletSpeed;
        public float fireRate;
        public float bulletDamage;
        public Sprite weaponSprite; // Картинка для отображения
    }

    public Weapon[] weapons; // Массив оружия
    public Transform firePoint; // Точка, из которой вылетает пуля
    public SpriteRenderer weaponSpriteRenderer; // Спрайт рендерер, который отображает оружие

    private int currentWeaponIndex = 0; // Индекс текущего оружия
    private float lastShotTime = 0f; // Время последнего выстрела

    void Start()
    {
        // Инициализация firePoint и SpriteRenderer, если они не назначены
        if (firePoint == null)
        {
            firePoint = new GameObject("FirePoint").transform;
            firePoint.parent = transform;
            firePoint.localPosition = Vector3.zero; // Располагаем в центре персонажа
        }

        if (weaponSpriteRenderer == null)
        {
            // Если не назначен, пытаемся найти его на этом же объекте
            weaponSpriteRenderer = GetComponent<SpriteRenderer>();
            if (weaponSpriteRenderer == null)
            {
                Debug.LogWarning("No SpriteRenderer assigned for weapon display.  Weapon sprites will not be shown.");
            }
        }

        UpdateWeaponSprite(); // Обновляем спрайт оружия при старте
    }


    void Update()
    {
        // Переключение оружия
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
            UpdateWeaponSprite(); // Обновляем спрайт оружия при смене
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
            UpdateWeaponSprite(); // Обновляем спрайт оружия при смене
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIndex = 2;
            UpdateWeaponSprite(); // Обновляем спрайт оружия при смене
        }

        // Проверка, есть ли вообще оружие
        if (weapons.Length == 0 || currentWeaponIndex >= weapons.Length)
        {
            Debug.LogWarning("No weapons defined or invalid weapon index.");
            return; // Останавливаем выполнение, если нет оружия
        }


        // Проверка, есть ли текущее оружие
        Weapon currentWeapon = weapons[currentWeaponIndex];
        if (currentWeapon == null || currentWeapon.bulletPrefab == null)
        {
            Debug.LogWarning("Current weapon or bulletPrefab is not assigned.");
            return; // Останавливаем выполнение, если нет оружия или префаба
        }



        // Проверяем ввод и возможность стрелять
        if (Input.GetButton("Fire1") && Time.time >= lastShotTime + currentWeapon.fireRate)
        {
            Shoot();
            lastShotTime = Time.time; // Обновляем время последнего выстрела
        }
    }

    void Shoot()
    {

        Weapon currentWeapon = weapons[currentWeaponIndex];
        // Получаем позицию мыши в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Вычисляем направление стрельбы
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        // Создаем пулю
        GameObject bullet = Instantiate(currentWeapon.bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        Bullet bulletScript = bullet.GetComponent<Bullet>(); // Получаем скрипт Bullet

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = shootDirection * currentWeapon.bulletSpeed; // Задаем скорость пули
        }
        else
        {
            Debug.LogError("У пули нет Rigidbody2D!");
            Destroy(bullet);
            return;
        }

        // Задаем урон пуле
        if (bulletScript != null)
        {
            bulletScript.damage = currentWeapon.bulletDamage;
        }
        else
        {
            Debug.LogError("У пули нет скрипта Bullet!");
            Destroy(bullet);
            return;
        }

        // Уничтожаем пулю через 5 секунд
        Destroy(bullet, 5f);
    }

    void UpdateWeaponSprite()
    {
        if (weaponSpriteRenderer != null && weapons.Length > 0 && currentWeaponIndex < weapons.Length && weapons[currentWeaponIndex].weaponSprite != null)
        {
            weaponSpriteRenderer.sprite = weapons[currentWeaponIndex].weaponSprite;
        }
        else
        {
            // Можно добавить логику, чтобы отображать отсутствие оружия или использовать спрайт по умолчанию
            if (weaponSpriteRenderer != null)
            {
                weaponSpriteRenderer.sprite = null; // Или можно установить спрайт по умолчанию.
            }
        }
    }
}