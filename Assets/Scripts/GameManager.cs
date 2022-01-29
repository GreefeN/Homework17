using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    [SerializeField] private CameraMove _camera;
    private UserInterface _userInterface;
    private Health _heroHealth;

    private void Awake()
    {
        _userInterface = GetComponent<UserInterface>();
        _heroHealth = _hero.GetComponent<Health>();
    }

    private void Update()
    {

        if (_heroHealth._isAlive) _userInterface._hpLine.fillAmount = _heroHealth._currentHealth / _heroHealth._maxHealth;
        else StartCoroutine("HeroDeath");
    }


    private IEnumerator HeroDeath()
    {
        _camera.Increase();
        _hero.GetComponent<Rigidbody2D>().simulated = false;
        yield return new WaitForSeconds(0.5f);
        _userInterface.ActivateDeathScreen();
    }
}
