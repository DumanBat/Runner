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
                platform._meshFilter.mesh = config.Mesh;
                platform._meshRenderer.sharedMaterial = config.Material;
                platform._obstacleConfigs = config.ObstacleConfigs;
                platform.transform.localScale = config.Scale;
                platform.transform.localPosition = config.LocalPosition;

                platform._obstacleGenerator.Init(platform.GetObstacleGenerationData());
            }
        }

        public struct ObstacleGenerationData
        {
            public int minObstacleAmount;
            public int maxObstacleAmount;
            public List<ObstacleConfig> obstacleConfigs;
            public List<Transform> obstacleSpawnPoints;
        }

        [Header("Platform Settings")]
        [SerializeField]
        private Transform _nextPlatformspawnPoint;
        [SerializeField]
        private List<Transform> _obstacleSpawnPoints;

        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private int _minObstacleAmount;
        private int _maxObstacleAmount;
        private ObstacleGenerator _obstacleGenerator;
        private List<ObstacleConfig> _obstacleConfigs;

        public Transform NextPlatformSpawnPoint => _nextPlatformspawnPoint;
        public ObstacleGenerator ObstacleGenerator => _obstacleGenerator;

        [Inject]
        private ObstacleGenerator.Factory _obstacleGeneratorFactory;


        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _obstacleGenerator = _obstacleGeneratorFactory.Create();
        }

        private ObstacleGenerationData GetObstacleGenerationData()
        {
            var obstacleData = new ObstacleGenerationData()
            {
                minObstacleAmount = _minObstacleAmount,
                maxObstacleAmount = _maxObstacleAmount,
                obstacleConfigs = _obstacleConfigs,
                obstacleSpawnPoints = _obstacleSpawnPoints
            };

            return obstacleData;
        }

        public void Unload()
        {
            _obstacleGenerator.Unload();
        }
    }
}
