using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость игрока
    private Rigidbody2D rb;
    private Vector2 moveInput;

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
    }

    void FixedUpdate()
    {
        // Применяем скорость к телу
        // normalized нужен, чтобы при движении по диагонали игрок не бегал быстрее
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}
