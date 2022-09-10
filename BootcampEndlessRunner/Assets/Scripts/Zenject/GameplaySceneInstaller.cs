using UnityEngine;
using Zenject;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.CameraService;
using Eventyr.EndlessRunner.Scripts.Player;
using Eventyr.EndlessRunner.Scripts.Utils;
using Eventyr.EndlessRunner.Scripts.Gameplay;
using Eventyr.EndlessRunner.Scripts.UI;

namespace Eventyr.EndlessRunner.Scripts.Zenject
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _cameraPrefab;
        [SerializeField]
        private DesktopInput _desktopInput;
        [SerializeField]
        private SwipeDetector _swipeDetector;
        [SerializeField]
        private ScoreView _scoreViewPrefab;
        [SerializeField]
        private GameResultsView _gameResultsViewPrefab;
        [SerializeField]
        private LevelGenerator _levelGenerator;
        [SerializeField]
        private Platform _platformPrefab;
        [SerializeField]
        private Obstacle _obstaclePrefab;
        [SerializeField]
        private Coin _coinPrefab;

        public override void InstallBindings()
        {
            BindCamera();
            BindInputService();
            BindLevelGenerator();
            BindObstacleGenerator();
            BindCoinGenerator();
            BindScoreController();
            BindGameResults();
            BindPlatformPool();
            BindObstaclePool();
            BindCoinsPool();
        }

        private void BindCamera()
        {
            var cameraFollow = Container.InstantiatePrefabForComponent<CameraFollow>(_cameraPrefab);

            Container.Bind<ICameraService>()
                .FromInstance(cameraFollow)
                .AsSingle();
        }

        private void BindInputService()
        {
            IInputService inputService;

            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
                inputService = Container.InstantiatePrefabForComponent<SwipeDetector>(_swipeDetector);
            else
                inputService = Container.InstantiatePrefabForComponent<DesktopInput>(_desktopInput);

            Container.Bind<IInputService>()
                .FromInstance(inputService)
                .AsSingle();
        }

        private void BindLevelGenerator()
        {
            Container.BindFactory<LevelGenerator, LevelGenerator.Factory>().FromComponentInNewPrefab(_levelGenerator);
        }

        private void BindObstacleGenerator()
        {
            Container.BindFactory<ObstacleGenerator, ObstacleGenerator.Factory>();
        }

        private void BindCoinGenerator()
        {
            Container.BindFactory<CoinsGenerator, CoinsGenerator.Factory>();
        }

        private void BindScoreController()
        {
            var scoreView = Container.InstantiatePrefabForComponent<ScoreView>(_scoreViewPrefab);

            Container.Bind<IScoringServiceView>()
                .FromInstance(scoreView)
                .AsSingle();

            Container.Bind<IScoringService>()
                .To<ScoreController>()
                .FromInstance(new ScoreController(scoreView))
                .AsSingle();
        }

        private void BindGameResults()
        {
            var gameResults = Container.InstantiatePrefabForComponent<GameResultsView>(_gameResultsViewPrefab);

            Container.Bind<IGameResults>()
                .FromInstance(gameResults)
                .AsSingle();
        }

        private void BindPlatformPool()
        {
            Container.BindMemoryPool<Platform, Platform.Pool>()
                .WithInitialSize(6)
                .FromComponentInNewPrefab(_platformPrefab);
        }

        private void BindObstaclePool()
        {
            Container.BindMemoryPool<Obstacle, Obstacle.Pool>()
                .WithInitialSize(3)
                .FromComponentInNewPrefab(_obstaclePrefab);
        }

        private void BindCoinsPool()
        {
            Container.BindMemoryPool<Coin, Coin.Pool>()
                .WithInitialSize(3)
                .FromComponentInNewPrefab(_coinPrefab);
        }
    }
}