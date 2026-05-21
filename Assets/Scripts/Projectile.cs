using System;
using UnityEngine;

namespace GameName.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 30f;

        // Префаб снаряда (возможен для визуала или переинициализации)
        [SerializeField] private GameObject _projectilePrefab;

        // Событие, вызываемое при столкновении
        // Action<Projectile> — передаёт ссылку на текущий снаряд
        public Action<Projectile> OnTriggered;

        // Направление движения снаряда
        // По умолчанию Vector2.zero — снаряд стоит
        private Vector2 _direction = Vector2.zero;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Если направление движения задано
            if (_direction != Vector2.zero)
            {
                // Задаём скорость Rigidbody:
                // normalized — чтобы скорость не зависела от длины вектора
                // умножаем на заданную скорость
                _rb.linearVelocity = _direction.normalized * _speed;
            }
        }

        // Публичный метод для запуска снаряда
        // Вызывается из PlayerMovement.Fire()
        public void Move(Vector2 direction)
        {
            // Сохраняем направление движения
            _direction = direction;
        }

        // Вызывается Unity при входе в триггер
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Проверяем, что столкнулись с окружением
            if (other.CompareTag("Environment"))
            {
                // Сообщение в консоль (диагностика)
                Debug.Log("Environment entered");

                // Вызываем событие, если есть подписчики
                // ?. — защита от null
                OnTriggered?.Invoke(this);
            }
        }
    }
}