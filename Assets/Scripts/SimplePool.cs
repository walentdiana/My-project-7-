// Подключаем коллекции (Queue)
using System.Collections.Generic;
using GameName.Projectiles;

// Unity API
using UnityEngine;

// Пространство имён для системы пуллинга
namespace GameName.Pooling
{
    // SimplePool — простой Object Pool для Projectile
    public class SimplePool : MonoBehaviour
    {
        // Префаб снаряда, который будет клонироваться
        // Задаётся в инспекторе
        public Projectile _prefab;

        // Сколько объектов создать заранее при старте
        public int _initialize;

        // Очередь для хранения неактивных снарядов
        // Queue — FIFO (кто первый зашёл, тот первый вышел)
        private Queue<Projectile> _pool = new Queue<Projectile>();

        // Awake вызывается один раз при создании объекта
        private void Awake()
        {
            // Создаём нужное количество снарядов заранее
            for (int i = 0; i < _initialize; i++)
            {
                // Создаём новый экземпляр префаба
                var obj = Instantiate(_prefab);

                // Отключаем объект, чтобы он не был виден и активен
                obj.gameObject.SetActive(false);

                // Добавляем объект в пул
                _pool.Enqueue(obj);
            }
        }

        // Получить снаряд из пула
        public Projectile Get()
        {
            // Если в пуле есть свободные объекты
            if (_pool.Count > 0)
            {
                // Забираем первый снаряд из очереди
                var obj = _pool.Dequeue();

                // Включаем объект в сцене
                obj.gameObject.SetActive(true);

                // Возвращаем готовый снаряд
                return obj;
            }

            // Если пул пуст — создаём новый снаряд
            var newObj = Instantiate(_prefab);

            // Возвращаем новый объект
            return newObj;
        }

        // Вернуть снаряд обратно в пул
        public void Return(Projectile obj)
        {
            // Отключаем объект
            obj.gameObject.SetActive(false);

            // Кладём его обратно в очередь
            _pool.Enqueue(obj);
        }
    }
}