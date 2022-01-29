using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _damage;
    private Health _health; //��� ��������� ���������� �������� ������� ��������

    /// <summary>
    /// ��� �������� ��� �������� (�����, �������)
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
    /// ��� �������� � ��������� (�������)
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool _isTrigger = gameObject.GetComponent<Collider2D>().isTrigger;
        if (collision.gameObject.GetComponentInParent<Health>())
        {
            _health = collision.gameObject.GetComponentInParent<Health>();
            _health.TakeDamage(_damage);
            if (!_health._isAlive) //���� ������ ���� ��������� ���������(��� �� �����������) � ����������� ����������, ��� �� �� ���������� ����� ��������
            {
                collision.GetComponentInParent<Rigidbody2D>().simulated = false;
                Destroy(collision.gameObject);
            }
        }
        if (collision && _isTrigger) Destroy(gameObject);
    }
}
