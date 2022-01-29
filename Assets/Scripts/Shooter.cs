using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile; //префаб снаряда
    [SerializeField] private float _speedProjectile;
    [SerializeField] private Transform _startPositionProjectile;
    private Transform _hero; //для определения направления поворота игрока

    private void Awake()
    {
        _hero = GetComponent<Transform>(); //получаем трансформ что б знать угол поворота игрока относительно оси Y
    }

    /// <summary>
    /// стреляет снарядами в сторону поворота игрока
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
