using UnityEngine;
using GameName.Input;
using GameName.Pooling;
using GameName.Projectiles;
using GameName.Player;
using UnityEngine.InputSystem;


namespace GameName.Fight 
{
    // Пул объектов для переиспользования снарядов
    public class FightComponent : MonoBehaviour
    {
        [SerializeField] private SimplePool _pool;
        private PlayerComponent _playerComponent;
        private Rigidbody2D _rb;
        private void Update()
        {
            // Если нажата кнопка стрельбы
            if (InputComponent.GetFire())
            {
                // Вызываем метод стрельбы
                Fire();
            }
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
           // obj.Move(obj.transform.right);
            
            obj.Move(new Vector2(transform.localScale.x, 0));
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