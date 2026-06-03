using UnityEngine; 

namespace GameName.Player 
{
    public class PlayerComponent : MonoBehaviour 
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 1f;
        [SerializeField] internal int _jumpMaxCount = 1; 
        
        // Свойство для доступа (только чтение)
        internal float JumpForce => _jumpForce;
        internal float Speed => _speed;

        private Rigidbody2D _rb;
        
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}