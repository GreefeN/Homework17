using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile; //������ �������
    [SerializeField] private float _speedProjectile;
    [SerializeField] private Transform _startPositionProjectile;
    private Transform _hero; //��� ����������� ����������� �������� ������

    private void Awake()
    {
        _hero = GetComponent<Transform>(); //�������� ��������� ��� � ����� ���� �������� ������ ������������ ��� Y
    }

    /// <summary>
    /// �������� ��������� � ������� �������� ������
    /// </summary>
    public void Shoot()
    {
        GameObject shootedProjectile = Instantiate(_projectile, _startPositionProjectile.position, Quaternion.identity);
        Rigidbody2D projectileBody = shootedProjectile.GetComponent<Rigidbody2D>();
        if (_hero.localEulerAngles.y == 0)
        {
            projectileBody.velocity = new Vector2(_speedProjectile * 1, projectileBody.velocity.y);
        }
        else
        {
            projectileBody.velocity = new Vector2(_speedProjectile * -1, projectileBody.velocity.y);
        }
    }
}
