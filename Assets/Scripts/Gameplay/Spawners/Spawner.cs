using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [Serializable]
        struct SpawnInfo
        {
            public GameObject obj;
            public float chance;
        }


        [SerializeField]
        private List<SpawnInfo> spawnObjects;
        
        [SerializeField]
        private Transform _parent;
        
        [SerializeField]
        private Vector2 _spawnPeriodRange;
        
        [SerializeField]
        private Vector2 _spawnDelayRange;

        [SerializeField]
        private bool _autoStart = true;

        private float _randomChanceLimit = 0;
        

        private void Start()
        {
            _randomChanceLimit = spawnObjects.Sum(item => item.chance);
            
            if (_autoStart)
                StartSpawn();
        }


        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }


        // выдает случайный элемент относительно его случайности
        public GameObject SelectRandomSpawnObject()
        {
            float random = Random.Range(0, _randomChanceLimit);
            for (int i = 0; i < spawnObjects.Count; i++)
            {
                if (random <= spawnObjects[i].chance)
                {
                    return spawnObjects[i].obj;
                }

                random -= spawnObjects[i].chance;
            }

            return null;
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
            
            while (true)
            {
                var obj = SelectRandomSpawnObject();
                if (obj)
                {
                    Instantiate(obj, transform.position, transform.rotation, _parent);
                }
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
