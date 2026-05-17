using UnityEngine; 

namespace GameName.Input 
{
    public class InputComponent : MonoBehaviour 
    {
        // Метод для получения направления движения (WASD / стрелки)
        internal static Vector2 GetMove() // internal = доступ внутри сборки, static = вызывается без создания объекта
        {
            // Создаем вектор из двух осей:
            // Horizontal = A/D или ←/→
            // Vertical = W/S или ↑/↓
            return new Vector2(
                UnityEngine.Input.GetAxis("Horizontal"), // Получаем горизонтальный ввод
                UnityEngine.Input.GetAxis("Vertical")    // Получаем вертикальный ввод
            );
        }

        // Метод для проверки прыжка
        internal static bool GetJump() // Возвращает true/false (нажата ли кнопка пыжка)
        {
            if (UnityEngine.Input.GetButtonDown("Jump"))
            {
                return true; 
            }

            return false; 
        }

        // Метод для проверки стрельбы
        internal static bool GetFire()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                return true; 
            }

            return false; 
        }
    }
}