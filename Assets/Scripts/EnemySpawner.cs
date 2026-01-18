using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Кого спавним
    public float spawnRate = 2f; // Раз в сколько секунд
    public float spawnDistance = 10f; // Дистанция от игрока, где появится враг

    private float timer;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0;

            // Постепенно уменьшаем время между спавном, но не ниже 0.3 сек
            if (spawnRate > 0.3f)
            {
                spawnRate -= 0.01f;
            }
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Генерируем случайное направление
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;

        // Вычисляем позицию: позиция игрока + направление + дистанция
        Vector3 spawnPos = (Vector2)player.position + (spawnDirection * spawnDistance);

        // Выбираем случайный индекс из массива
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        // Создаем случайного врага
        Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}
