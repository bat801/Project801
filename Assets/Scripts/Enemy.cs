using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;
    public float moveSpeed = 3f; // Скорость врага
    public GameObject deathEffectPrefab;

    private Rigidbody2D rb;
    private Transform player; // Ссылка на трансформ игрока

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ищем объект с тегом "Player" на сцене
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Вычисляем направление к игроку
            Vector2 direction = (player.position - transform.position).normalized;

            // Двигаем врага через velocity
            rb.velocity = direction * moveSpeed;

            // Дополнительно: поворачиваем треугольник "носом" к игроку
            // Вычисляем угол (в радианах, затем переводим в градусы)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // Вычитаем 90 градусов, чтобы компенсировать разницу между "право" и "верх"
            rb.rotation = angle - 90f;
        }
    }

    // Этот метод вызывается Unity автоматически, когда что-то входит в триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка на игрока
        if (other.CompareTag("Player"))
        {
            // Ищем у объекта, в который врезались компонент PlayerHealth
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10f); // Наносим 10 урона
            }

            Die(); // Враг исчезает после удара
        }

        // Проверяем, есть ли у объекта, который в нас врезался, тег "Bullet"
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(5f); // Отнимаем 5 ХП
            Destroy(other.gameObject); // Уничтожаем пулю
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        // Ищем GameManager на сцене и вызываем метод добавления очков
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.AddScore(1); // +1 за каждого убитого
        }

        Destroy(gameObject);
    }
}
