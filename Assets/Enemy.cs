using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;

    // Этот метод вызывается Unity автоматически, когда что-то входит в триггер
    void OnTriggerEnter2D(Collider2D other)
    {
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
        // Позже добавим здесь эффекты или опыт
        Destroy(gameObject);
    }
}
