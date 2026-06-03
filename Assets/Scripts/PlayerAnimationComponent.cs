using UnityEngine;

namespace GameName.Player
{
    public class PlayerAnimationComponent : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rb;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            // Движение
            bool isMove = Mathf.Abs(_rb.linearVelocity.x) > 0.1f;
            _animator.SetBool("bIsMove", isMove);

            // Прыжок вверх
            bool isJump = _rb.linearVelocity.y > 0.1f;
            _animator.SetBool("bIsJump", isJump);

            // Падение
            bool isFall = _rb.linearVelocity.y < -0.1f;
            _animator.SetBool("bIsFall", isFall);

            // Двойной прыжок
            _animator.SetBool("bDoubleJump", _playerMovement.isSecondJump);
        }
    }
}