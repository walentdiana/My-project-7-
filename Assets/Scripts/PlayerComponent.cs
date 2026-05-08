using System;
using UnityEngine;


namespace Dziana.Player
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(PlayerMovementComponent))]
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        internal float MoveSpeed => _moveSpeed;
        
        [SerializeField] private float _jumpForce = 1;
        internal float JumpForce => _jumpForce;
        
        private Rigidbody2D _rb;
        private PlayerMovementComponent _playerMovementComponent;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}

