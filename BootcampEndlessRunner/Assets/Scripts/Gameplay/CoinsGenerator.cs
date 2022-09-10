using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class CoinsGenerator
    {
        public class Factory : PlaceholderFactory<CoinsGenerator>
        {
        }

        private IScoringService _scoringService;
        private Platform _originPlatform;
        private Coin.Pool _coinPool;
        private int _minCoinsAmount;
        private int _maxCoinsAmount;

        private List<Transform> _coinSpawnPoints;
        private List<Coin> _spawnedCoins;

        public List<Coin> SpawnedCoins => _spawnedCoins;

        public CoinsGenerator()
        {
            _spawnedCoins = new List<Coin>();
        }

        [Inject]
        public void Construct(Coin.Pool coinPool, IScoringService scoringService)
        {
            _scoringService = scoringService;
            _coinPool = coinPool;
        }

        public void Init(Platform.CoinGenerationData coinGenerationData)
        {
            _originPlatform = coinGenerationData.originPlatform;
            _minCoinsAmount = coinGenerationData.minCoinsAmount;
            _maxCoinsAmount = coinGenerationData.maxCoinsAmount;
            _coinSpawnPoints = coinGenerationData.originPlatform.PlatformSpawnPoints;
        }

        public void SpawnCoins()
        {
            var obstacleAmount = Random.Range(_minCoinsAmount, _maxCoinsAmount + 1);
            var activeCoinsSpawnPoints = _originPlatform.ActiveSpawnPoints;

            for (int i = 0; i < obstacleAmount; i++)
            {
                var obstacleSpawnPoint = GetObstacleSpawnPoint(activeCoinsSpawnPoints);
                activeCoinsSpawnPoints.Add(obstacleSpawnPoint);

                var coin = _coinPool.Spawn();
                coin.OriginGenerator = this;
                coin.transform.SetParent(obstacleSpawnPoint);
                coin.transform.localPosition = Vector3.zero;
                coin.PickedUp += _scoringService.AddScore;
                _spawnedCoins.Add(coin);
            }
        }

        private Transform GetObstacleSpawnPoint(List<Transform> activeCoinSpawnPoints)
        {
            var randomIndex = Random.Range(0, _coinSpawnPoints.Count);
            return activeCoinSpawnPoints.Contains(_coinSpawnPoints[randomIndex])
                ? GetObstacleSpawnPoint(activeCoinSpawnPoints)
                : _coinSpawnPoints[randomIndex];
        }

        public void Unload()
        {
            foreach (var spawnedCoin in _spawnedCoins)
            {
                spawnedCoin.Unload();
            }

            _spawnedCoins.Clear();
        }
    }
}
