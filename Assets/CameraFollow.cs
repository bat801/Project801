using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Сюда перетащим игрока
    public Vector3 offset = new Vector3(0, 0, -10); // Дистанция камеры от игрока

    void LateUpdate()
    {
        // Камера просто копирует позицию игрока + отступ
        transform.position = target.position + offset;
    }
}
