using UnityEngine; 

namespace GameName.Player 
{
    // Требуем, чтобы на объекте обязательно были эти компоненты:
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerMovement))]
    public class PlayerComponent : MonoBehaviour 
    {
        [SerializeField] private float _speed = 1f;

        // Свойство для доступа к скорости (только чтение)
        internal float Speed => _speed;

        // Сила прыжка
        [SerializeField] private float _jumpForce = 1f;
        
        // Свойство для доступа к силе прыжка(только чтение)
        internal float JumpForce => _jumpForce;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}