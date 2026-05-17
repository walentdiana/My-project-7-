
using UnityEngine;
using GameName.Input;
using GameName.Pooling;
using GameName.Projectile;

namespace GameName.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        private float _groundCheckDistance = 0.5f;
        private bool _bIsGrounded;

        private PlayerComponent _playerComponent;
        private Rigidbody2D _rb;
        
        // Префаб/объект снаряда
        [SerializeField] private Projectile _projectile;
        // Компонент ввода (кнопки, оси, выстрел и т.п.)
        [SerializeField] private InputComponent _inputComponent;
        // Пул объектов для переиспользования снарядов
        [SerializeField] private SimplePool _pool;
        // Вызывается Unity один раз при создании объекта
        
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerComponent = GetComponent<PlayerComponent>();
        }

        private void Update()
        {
            // Проверяем: нажата ли кнопка прыжка И игрок стоит на земле
            if (InputComponent.GetJump() && _bIsGrounded)
            {
                // Задаём новую скорость:
                // X — оставляем прежнюю
                // Y — задаём силу прыжка
                _rb.linearVelocity = new Vector2(
                    _rb.linearVelocity.x,
                    _playerComponent.JumpForce
                );
            }

            // Если нажата кнопка стрельбы
            if (InputComponent.GetFire())
            {
                // Вызываем метод стрельбы
                Fire();
            }
        }

        private void FixedUpdate()
        {
            // Проверяем землю под игроком
            // OverlapCircle возвращает true, если круг касается слоя земли
            _bIsGrounded = Physics2D.OverlapCircle(
                transform.position,        // позиция игрока
                _groundCheckDistance,       // радиус проверки
                _groundLayer                // слой земли
            );

            // Получаем направление движения из InputComponent
            Vector2 moveDir = InputComponent.GetMove();

            // Обновляем скорость движения игрока
            // X — движение влево/вправо
            // Y — сохраняем текущую вертикальную скорость (прыжок / падение)
            _rb.linearVelocity = new Vector2(
                moveDir.x * _playerComponent.Speed,
                _rb.linearVelocity.y
            );
        }

        // Метод стрельбы
        private void Fire()
        {
            // Берём снаряд из пула (без создания нового объекта)
            var obj = _pool.Get();

            // Ставим снаряд в позицию игрока
            obj.transform.position = transform.position;

            // Копируем поворот игрока
            obj.transform.rotation = transform.rotation;

            // Подписываемся на событие столкновения снаряда
            obj.OnTriggered += ProjectileHandler;

            // Запускаем движение снаряда
            // transform.right — направление "вперёд" объекта
            obj.Move(obj.transform.right);
        }

        // Метод, который вызывается при попадании снаряда
        private void ProjectileHandler(Projectile obj)
        {
            // Отписываемся от события, чтобы избежать утечек
            obj.OnTriggered -= ProjectileHandler;

            // Возвращаем снаряд обратно в пул
            _pool.Return(obj);
        }
    }
}
