using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float _maxHealth;
    private Animator _anim;
    public float _currentHealth;
    public bool _isAlive = true;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CheckIsAlive();
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
