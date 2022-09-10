using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class Platform : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<PlatformConfig, Platform>
        {
            protected override void Reinitialize(PlatformConfig config, Platform platform)
            {
                platform._minObstacleAmount = config.MinObstacleAmount;
                platform._maxObstacleAmount = config.MaxObstacleAmount;
                platform._minCoinsAmount = config.MinCoinsAmount;
                platform._maxCoinsAmount = config.MaxCoinsAmount;
                platform._meshFilter.mesh = config.Mesh;
                platform._meshRenderer.sharedMaterial = config.Material;
                platform._obstacleConfigs = config.ObstacleConfigs;
                platform.transform.localScale = config.Scale;
                platform.transform.localPosition = config.LocalPosition;

                platform._obstacleGenerator.Init(platform.GetObstacleGenerationData());
                platform._coinsGenerator.Init(platform.GetCoinGenerationData());
            }
        }

        public struct ObstacleGenerationData
        {
            public Platform originPlatform;
            public int minObstacleAmount;
            public int maxObstacleAmount;
            public List<ObstacleConfig> obstacleConfigs;
        }

        public struct CoinGenerationData
        {
            public Platform originPlatform;
            public int minCoinsAmount;
            public int maxCoinsAmount;
        }

        [Header("Platform Settings")]
        [SerializeField]
        private Transform _nextPlatformspawnPoint;
        [SerializeField]
        private List<Transform> _platformSpawnPoints;

        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private int _minObstacleAmount;
        private int _maxObstacleAmount;
        private int _minCoinsAmount;
        private int _maxCoinsAmount;
        private ObstacleGenerator _obstacleGenerator;
        private CoinsGenerator _coinsGenerator;
        private List<ObstacleConfig> _obstacleConfigs;
        private List<Transform> _activeSpawnPoints;

        [Inject]
        private ObstacleGenerator.Factory _obstacleGeneratorFactory;
        [Inject]
        private CoinsGenerator.Factory _coinsGeneratorFactory;

        public Transform NextPlatformSpawnPoint => _nextPlatformspawnPoint;
        public List<Transform> PlatformSpawnPoints => _platformSpawnPoints;
        public ObstacleGenerator ObstacleGenerator => _obstacleGenerator;
        public CoinsGenerator CoinsGenerator => _coinsGenerator;
        public List<Transform> ActiveSpawnPoints => _activeSpawnPoints;

        private void Awake()
        {
            _activeSpawnPoints = new List<Transform>();
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _obstacleGenerator = _obstacleGeneratorFactory.Create();
            _coinsGenerator = _coinsGeneratorFactory.Create();
        }

        public void Unload()
        {
            _activeSpawnPoints.Clear();
            _obstacleGenerator.Unload();
            _coinsGenerator.Unload();
        }

        private ObstacleGenerationData GetObstacleGenerationData()
        {
            var obstacleData = new ObstacleGenerationData()
            {
                originPlatform = this,
                minObstacleAmount = _minObstacleAmount,
                maxObstacleAmount = _maxObstacleAmount,
                obstacleConfigs = _obstacleConfigs
            };

            return obstacleData;
        }

        private CoinGenerationData GetCoinGenerationData()
        {
            var coinData = new CoinGenerationData()
            {
                originPlatform = this,
                minCoinsAmount = _minCoinsAmount,
                maxCoinsAmount = _maxCoinsAmount
            };

            return coinData;
        }
    }
}
