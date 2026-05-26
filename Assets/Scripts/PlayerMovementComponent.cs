
using UnityEngine;
using GameName.Input;

namespace GameName.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 2f;
        private bool _bIsGrounded;

        private PlayerComponent _playerComponent;
        private Rigidbody2D _rb;

        private int _jumpCount = 0;

        // Компонент ввода (кнопки, оси, выстрел и т.п.)
        [SerializeField] private InputComponent _inputComponent;
        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerComponent = GetComponent<PlayerComponent>();
        }

        private void Update()
        {
            Jump();
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

        private void Jump()
        {
            // Проверяем: нажата ли кнопка прыжка И игрок стоит на земле или он прыгнул меньше 1 раза
            if (InputComponent.GetJump() && (_bIsGrounded || _jumpCount < 1))
            {
                // Задаём новую скорость:
                // X — оставляем прежнюю
                // Y — задаём силу прыжка
                _rb.linearVelocity = new Vector2(
                    _rb.linearVelocity.x,
                    _playerComponent.JumpForce
                );
                _jumpCount++;
            }
            
            if (_bIsGrounded)
            {
                _jumpCount = 0;
            }
        }
    }
}
