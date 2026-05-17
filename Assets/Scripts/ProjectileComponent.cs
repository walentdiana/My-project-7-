using System;
using UnityEngine;
using Dziana.Pooling;


namespace Dziana.ProjectTile
{

    public class ProjectileComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private GameObject _projectilePrefab;

        public Action<ProjectileComponent> OnTriggered;

        private Vector2 _direction = Vector2.zero;
        
        private Rigidbody2D _rb;

        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(_direction != Vector2.zero)
            {
                _rb.linearVelocity = _direction.normalized * _speed;
            }
        }

        public void Move(Vector2 direction)
        {
            _direction = direction;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Environment"))
            {
                Debug.Log("Environment Entered");
                OnTriggered?.Invoke(this);
            }
        }
        
    }
    
    
}
