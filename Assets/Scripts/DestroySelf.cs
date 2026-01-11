using UnityEngine;

public class DestroySelf : MonoBehaviour {   
    void Start()    {   Destroy(gameObject, 1f);    } // Удалит эффект через 1 секунду
}
