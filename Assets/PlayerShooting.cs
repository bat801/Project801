using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Сюда перетащим префаб пули
    public Transform firePoint; // Точка, откуда вылетает пуля
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Левая кнопка мыши
        {
            Shoot();
        }

    }

    void Shoot()
    {
        // Создаем пулю в точке firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Толкаем пулю вперед (в направлении "правой" стороны объекта стрельбы)
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        // Удаляем пулю через 2 секунды, чтобы не засорять память
        Destroy(bullet, 2f);
    }
}
