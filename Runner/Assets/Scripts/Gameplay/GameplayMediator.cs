using Eventyr.EndlessRunner.Scripts.CameraService;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class GameplayMediator : MonoBehaviour
    {
        private ICameraService _cameraService;
        private LevelGenerator.Factory _levelGeneratorFactory;
        private IGameResults _gameResults;
        private IScoringService _scoringService;

        private LevelGenerator _levelGenerator;
        private PlayerController _player;

        [Inject]
        private PlayerController.Factory _playerControllerFactory;

        [Inject]
        public void Construct(ICameraService cameraService, LevelGenerator.Factory levelGenerator, IGameResults gameResults, IScoringService scoringService)
        {
            _cameraService = cameraService;
            _levelGeneratorFactory = levelGenerator;
            _gameResults = gameResults;
            _scoringService = scoringService;
        }

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _player = _playerControllerFactory.Create();
            _levelGenerator = _levelGeneratorFactory.Create();

            _cameraService.Init(_player.transform);
            _levelGenerator.Init(_player.Rigidbody);
            _scoringService.Init();

            _player.Health.Died += StopGame;
            _player.Init();
        }

        private void StopGame()
        {
            _gameResults.ShowResults(_scoringService.Score);
            _gameResults.PlayAgainButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            _levelGenerator.Unload();

            _player.Rigidbody.position = Vector3.zero;
            _cameraService.Init(_player.transform);
            _levelGenerator.Init(_player.Rigidbody);
            _scoringService.Init();
            _player.Init();

            _gameResults.SetActivePanel(false);
        }
    }
}
