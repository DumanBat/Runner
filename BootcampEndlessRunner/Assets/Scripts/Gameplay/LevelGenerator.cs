using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class LevelGenerator : MonoBehaviour, ILevelGenerationService
    {
        public class Factory : PlaceholderFactory<LevelGenerator>
        {
        }

        [SerializeField]
        private List<PlatformConfig> _platformConfigs;
        [SerializeField]
        private int _initialPlatformAmount;
        [SerializeField]
        private float _distanceToSpawn;

        private Rigidbody _playerRigidbody;
        private Platform _lastPlatform;
        private List<Platform> _spawnedPlatforms;

        private Platform.Pool _platformPool;

        private void Update()
        {
            if (CheckDistance(_distanceToSpawn))
                CyclePlatforms();
        }

        [Inject]
        public void Construct(Platform.Pool platformPool)
        {
            _platformPool = platformPool;
        }

        public void Init(Rigidbody playerRigidbody)
        {
            _playerRigidbody = playerRigidbody;

            _spawnedPlatforms = new List<Platform>();
            SpawnInitialPlatforms();
        }

        private void SpawnInitialPlatforms()
        {
            for (int i = 0; i < _initialPlatformAmount; i++)
            {
                SpawnPlatform(_platformConfigs[0]);
            }
        }

        public bool CheckDistance(float distance) => Vector3.Distance(_playerRigidbody.position, _lastPlatform.transform.position) <= distance;

        public void CyclePlatforms()
        {
            var platformToRelease = _spawnedPlatforms[0];
            _spawnedPlatforms.Remove(platformToRelease);
            _platformPool.Despawn(platformToRelease);
            platformToRelease.Unload();


            var platformConfig = _platformConfigs[Random.Range(0, _platformConfigs.Count)];
            var platform = SpawnPlatform(platformConfig);
            platform.ObstacleGenerator.SpawnObstacles();
            platform.CoinsGenerator.SpawnCoins();
        }

        public Platform SpawnPlatform(PlatformConfig platformConfig)
        {
            var spawnPos = _lastPlatform != null
                ? _lastPlatform.NextPlatformSpawnPoint.position
                : Vector3.zero;

            var platform = _platformPool.Spawn(platformConfig);
            platform.transform.position = spawnPos;
            _lastPlatform = platform;
            _spawnedPlatforms.Add(platform);
            return platform;
        }

        public void Unload()
        {
            foreach (var spawnedPlatform in _spawnedPlatforms)
            {
                spawnedPlatform.Unload();
                _platformPool.Despawn(spawnedPlatform);
            }

            _spawnedPlatforms.Clear();
            _lastPlatform = null;
        }
    }
}
