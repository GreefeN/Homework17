using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    public float _maxHealth;
    public float _currentHealth;
    public bool _isAlive = true;

    private Animator _anim;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CheckIsAlive();

        _anim.SetTrigger("Damage"); //для перехода к анимации получения урона
    }

    private void CheckIsAlive()
    {
        if (_currentHealth < 0)
        {
            _isAlive = !_isAlive;
            _anim.SetBool("isDead", !_isAlive);
        }
    }
}
