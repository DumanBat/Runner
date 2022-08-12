using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class ObstacleGenerator
    {
        public class Factory : PlaceholderFactory<ObstacleGenerator>
        {
        }

        private int _minObstacleAmount;
        private int _maxObstacleAmount;
        private List<ObstacleConfig> _obstacleConfigs;
        private List<Transform> _obstacleSpawnPoints;

        private Obstacle.Pool _obstaclePool;
        private List<Obstacle> _spawnedObstacles;

        public ObstacleGenerator()
        {
            _spawnedObstacles = new List<Obstacle>();
        }

        [Inject]
        public void Construct(Obstacle.Pool obstaclePool)
        {
            _obstaclePool = obstaclePool;
        }

        public void Init(Platform.ObstacleGenerationData obstacleGenerationData)
        {
            _minObstacleAmount = obstacleGenerationData.minObstacleAmount;
            _maxObstacleAmount = obstacleGenerationData.maxObstacleAmount;
            _obstacleConfigs = obstacleGenerationData.obstacleConfigs;
            _obstacleSpawnPoints = obstacleGenerationData.obstacleSpawnPoints;
        }

        public void SpawnObstacles()
        {
            var obstacleAmount = Random.Range(_minObstacleAmount, _maxObstacleAmount + 1);
            var activeObstacleSpawnPoints = new List<Transform>();

            for (int i = 0; i < obstacleAmount; i++)
            {
                var obstacleConfig = _obstacleConfigs[Random.Range(0, _obstacleConfigs.Count)];
                var obstacleSpawnPoint = GetObstacleSpawnPoint(activeObstacleSpawnPoints);
                activeObstacleSpawnPoints.Add(obstacleSpawnPoint);

                var obstacle = _obstaclePool.Spawn(obstacleConfig);
                obstacle.transform.SetParent(obstacleSpawnPoint);
                obstacle.transform.localPosition = Vector3.zero;
                _spawnedObstacles.Add(obstacle);
            }
        }

        private Transform GetObstacleSpawnPoint(List<Transform> activeObstacleSpawnPoints)
        {
            var randomIndex = Random.Range(0, _obstacleSpawnPoints.Count);
            return activeObstacleSpawnPoints.Contains(_obstacleSpawnPoints[randomIndex])
                ? GetObstacleSpawnPoint(activeObstacleSpawnPoints)
                : _obstacleSpawnPoints[randomIndex];
        }

        public void Unload()
        {
            foreach (var spawnedObstacle in _spawnedObstacles)
            {
                _obstaclePool.Despawn(spawnedObstacle);
            }

            _spawnedObstacles.Clear();
        }
    }
}
