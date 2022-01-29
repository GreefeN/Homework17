using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField, Range(-5, 5)] private float _offsetHor = 0f; //для настройки смещения камеры по горизонтали относительно игрока
    [SerializeField, Range(-5, 5)] private float _offsetVer = 0f; //для настройки смещения камеры по вертикали относительно игрока
    [SerializeField] private float _speed = 2f;
    private Camera _camera;
    private float _actualSize;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _actualSize = _camera.orthographicSize;
        transform.position = new Vector3(_hero.transform.position.x + _offsetHor, _hero.transform.position.y + _offsetVer, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_hero.transform.position.x + _offsetHor, _hero.transform.position.y + _offsetVer, transform.position.z), _speed * Time.deltaTime);
    }

    public void Increase()
    {
        _camera.orthographicSize = 1f;
    }
}
