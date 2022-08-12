using UnityEngine;
using Zenject;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.CameraService;
using Eventyr.EndlessRunner.Scripts.Player;
using Eventyr.EndlessRunner.Scripts.Utils;
using Eventyr.EndlessRunner.Scripts.Gameplay;

namespace Eventyr.EndlessRunner.Scripts.Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _cameraPrefab;
        [SerializeField]
        private DesktopInput _desktopInput;
        [SerializeField]
        private SwipeDetector _swipeDetector;
        [SerializeField]
        private LevelGenerator _levelGenerator;
        [SerializeField]
        private Platform _platformPrefab;
        [SerializeField]
        private Obstacle _obstaclePrefab;


        public override void InstallBindings()
        {
            BindCamera();
            BindInputService();
            BindLevelGenerator();
            BindObstacleGenerator();
            BindPlatformPool();
            BindObstaclePool();
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
    }
}