using System;
using Dziana.Input;
using UnityEngine;

namespace Dziana.Player
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;

        private float _groundCheckDistanse = 0.5f;

        private bool _bIsGrounded;

        private PlayerComponent _playerComponent;
        private Rigidbody2D _rb;
        private InputComponent _inputComponent;
        [SerializeField]private SimplePool _pool;
        
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputComponent = GetComponent<InputComponent>();
            _playerComponent = GetComponent<PlayerComponent>();
        }


        private void Update()
        {
            if (Input.InputComponent.BIsJump() && _bIsGrounded)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _playerComponent.JumpForce);
            }

            if (InputComponent.BIsFire())
            {
                Fire();
            }
        }

        private void FixedUpdate()
        {
            _bIsGrounded = Physics2D.OverlapCircle(transform.position, _groundCheckDistanse, _groundLayer);

            
            Vector2 moveDirection = InputComponent.GetMove();
            
            
            _rb.linearVelocity = new Vector2(
                moveDirection.x *  _playerComponent.MoveSpeed, _rb.linearVelocity.y);
        }

        private void Fire()
        {
            var obj = _pool.Get();
            
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.OnTriggered += ProjectTileHandler;
            obj.Move(obj.transform.right);
        }

        private void ProjectTileHandler(ProfectTile obj)
        {
            obj.OnTriggered -= ProjectTileHandler;
            _pool.Return(obj);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _bIsGrounded  ? Color.green : Color.red;
            
            Gizmos.DrawWireSphere(transform.position, _groundCheckDistanse);
        }
    }
    
    
}