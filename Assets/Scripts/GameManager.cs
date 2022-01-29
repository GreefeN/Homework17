using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UserInterface))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private CameraMove _camera;
    private UserInterface _userInterface;
    private PlayerInput _playerInpur;
    private Health _heroHealth;

    private void Awake()
    {
        _userInterface = GetComponent<UserInterface>();
        if (_hero != null)
        {
            _playerInpur = _hero.GetComponent<PlayerInput>();
            _heroHealth = _hero.GetComponent<Health>();
        }
    }

    private void Update()
    {
        if (_heroHealth._isAlive) _userInterface._hpLine.fillAmount = _heroHealth._currentHealth / _heroHealth._maxHealth; //������������� ������� �������� ��������
        else StartCoroutine("HeroDeath");
    }

    /// <summary>
    /// �������� � ������ ������ ������
    /// </summary>
    /// <returns></returns>
    private IEnumerator HeroDeath()
    {
        _playerInpur._heroAlive = false; //��������� ���������� ������ � ������ ������
        _camera.Increase();
        yield return new WaitForSeconds(0.5f);
        _userInterface.ActivateDeathScreen();
    }
}
