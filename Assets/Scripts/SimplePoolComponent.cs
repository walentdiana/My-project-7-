using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dziana.Pooling
{
    public class SimplePoolComponent : MonoBehaviour
    {
        public ProjectTile _prefab;
        public int _poolSize = 10;
        
        private Queue<ProjectTile> _pool = new Queue<ProjectTile>();

        private void Awake()
        {
            for(int i = 0; i < _poolSize; i++)
            {
                var obj = Instantiate(_prefab);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }
        
        public ProjectTile Get()
        {
            if (_pool.Count == 0)
            {
                var obj = _pool.Dequeue();
                obj.gameObject.SetActive(true);
                return(obj);
            }
            
            var newObj = Instantiate(_prefab);
            return newObj;
        }

        public void Return()
        {
            obj.gameObject.SetActive(false);
            
            _pool.Enqueue(obj);
        }
    }
    
    
}

