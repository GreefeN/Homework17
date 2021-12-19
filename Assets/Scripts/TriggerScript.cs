using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerScript : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _action.Invoke(); //выполняется назначенное действие в случае срабатывания триггера
    }
}
