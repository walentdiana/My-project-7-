using System;
using System.Collections.Generic;
using Dziana.ProjectTile;
using UnityEngine;

namespace Dziana.Pooling
{
    public class SimplePoolComponent : MonoBehaviour
    {
        public ProjectileComponent _prefab;
        public int _poolSize = 3;
        
        private Queue<ProjectileComponent> _pool = new Queue<ProjectileComponent>();

        
        private void Awake()
        {
            for(int i = 0; i < _poolSize; i++)
            {
                var obj = Instantiate(_prefab);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }
        
        
        public ProjectileComponent Get()
        {
            if (_pool.Count > 0)
            {
                var obj = _pool.Dequeue();
                obj.gameObject.SetActive(true);
                return(obj);
            }
            
            var newObj = Instantiate(_prefab);
            return newObj;
        }

        
        public void Return(ProjectileComponent obj)
        {
            obj.gameObject.SetActive(false);
            
            _pool.Enqueue(obj);
        }
    }
    
    
}

