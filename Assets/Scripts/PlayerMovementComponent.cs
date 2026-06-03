
using UnityEngine;
using GameName.Input;

namespace GameName.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 2f;

        private PlayerComponent _playerComponent;
        private Rigidbody2D _rb;
        [SerializeField] private InputComponent _inputComponent;

        private int _jumpCount = 0;

        public bool isSecondJump;
        private bool _bIsGrounded;
        private bool _wasGrounded;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerComponent = GetComponent<PlayerComponent>();
        }

        private void Update()
        {
            //Jump();
            Jumpp();
        }

        private void FixedUpdate()
        {
            // // Проверяем землю под игроком
            // // OverlapCircle возвращает true, если круг касается слоя земли
            _bIsGrounded = Physics2D.OverlapCircle(
                transform.position, // позиция игрока
                _groundCheckDistance, // радиус проверки
                _groundLayer); // слой земли

            // Получаем направление движения из InputComponent
            Vector2 moveDir = InputComponent.GetMove();

            // Обновляем скорость движения игрока
            // X — движение влево/вправо
            // Y — сохраняем текущую вертикальную скорость (прыжок / падение)
            _rb.linearVelocity = new Vector2(
                moveDir.x * _playerComponent.Speed,
                _rb.linearVelocity.y
            );

            Flip();
        }

        private void Flip()
        {
            if (_rb.linearVelocity.x != 0)
            {

                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x) * Mathf.Sign(_rb.linearVelocity.x);
                transform.localScale = scale;

            }
        }

        // private void Jump()
        // {
        //     // Проверяем: нажата ли кнопка прыжка И игрок стоит на земле или он прыгнул меньше 1 раза
        //     if (_inputComponent.GetJump() && (_bIsGrounded || _jumpCount < 2))
        //     {
        //         _rb.linearVelocity = new Vector2(
        //             _rb.linearVelocity.x,
        //             _playerComponent.JumpForce
        //         );
        //         _jumpCount++;
        //     }
        //     
        //     if (_bIsGrounded)
        //     {
        //         _jumpCount = 0;
        //     }
        // }

        private void Jumpp()
        {
            {
                if (_bIsGrounded && !_wasGrounded)
                {
                    _jumpCount = _playerComponent._jumpMaxCount;
                    isSecondJump = false;
                }

                if (_inputComponent.GetJump() && _jumpCount > 0)
                {
                    _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _playerComponent.JumpForce);
                    _jumpCount--;
                }

                if ((_jumpCount == 0) && !_bIsGrounded)
                {
                    isSecondJump = true;
                }
                
                _wasGrounded = _bIsGrounded;
            }
        }
    }
}
