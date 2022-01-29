using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
[AddComponentMenu("Player Components/Player Input")]
public class PlayerInput : MonoBehaviour
{
    public bool _heroAlive = true;
    private PlayerMovement _playerMovement;
    private Shooter _playerShoot;
    private float _horizontalDirection;
    private bool _isPressJump;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShoot = GetComponent<Shooter>();
    }

    void Update()
    {
        if (_heroAlive) //если игрок жив
        {
            _horizontalDirection = Input.GetAxis(HORIZONTAL_AXIS);
            _isPressJump = Input.GetButtonDown(JUMP);
            _playerMovement.Move(_horizontalDirection, _isPressJump);

            if (Input.GetButtonDown(FIRE))
            {
                _playerShoot.Shoot();
            }
        }
    }
}
