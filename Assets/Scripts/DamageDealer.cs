using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Health _health; //для получения компонента здоровья объекта коллизии

    /// <summary>
    /// для объектов без удаления (враги, ловушки)
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Health>())
        {
            _health = collision.gameObject.GetComponentInParent<Health>();
            _health.TakeDamage(_damage);
        }
    }

    /// <summary>
    /// для объектов с удалением (снаряды)
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool _isTrigger = gameObject.GetComponent<Collider2D>().isTrigger;
        if (collision.gameObject.GetComponentInParent<Health>())
        {
            _health = collision.gameObject.GetComponentInParent<Health>();
            _health.TakeDamage(_damage);
            if (!_health._isAlive) //если объект умер удаляется коллайдер(так же дамагдиллер) и отключается симмуляция, что бы не провалился через текстуры
            {
                collision.GetComponentInParent<Rigidbody2D>().simulated = false;
                Destroy(collision.gameObject);
            }
        }
        if (collision && _isTrigger) Destroy(gameObject);
    }
}
