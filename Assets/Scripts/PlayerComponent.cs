using UnityEngine;


namespace Player
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(PlayerMovementComponent))]
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 1;
    }
}

