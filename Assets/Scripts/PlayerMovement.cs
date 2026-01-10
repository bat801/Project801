using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость игрока
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 mousePos; // Добавляем переменную для позиции мыши

    public Camera cam; // Сюда перетащим камеру в инспекторе

    // Start is called before the first frame update
    void Start()
    {
        // Получаем ссылку на компонент, который мы добавили в Unity
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Считываем нажатия клавиш (WASD / Стрелки)
        // Возвращает значения от -1 до 1
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Получаем позицию мыши из экранных координат в мировые
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // Применяем скорость к телу
        // normalized нужен, чтобы при движении по диагонали игрок не бегал быстрее
        rb.velocity = moveInput.normalized * moveSpeed;

        // ЛОГИКА ПОВОРОТА:
        // Вычисляем вектор направления от игрока к мыши
        Vector2 lookDir = mousePos - rb.position;

        // Вычисляем угол в градусах через арктангенс
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Применяем поворот к Rigidbody
        rb.rotation = angle;
    }
}
