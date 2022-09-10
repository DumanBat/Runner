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
        private IGameResults _gameResults;
        private IScoringService _scoringService;
        private IUserDataControllerService _dataControllerService;

        private LevelGenerator _levelGenerator;
        private PlayerController _player;

        [Inject]
        private PlayerController.Factory _playerControllerFactory;
        [Inject]
        private LevelGenerator.Factory _levelGeneratorFactory;


        [Inject]
        public void Construct(ICameraService cameraService, IGameResults gameResults, IScoringService scoringService, IUserDataControllerService dataControllerService)
        {
            _cameraService = cameraService;
            _gameResults = gameResults;
            _scoringService = scoringService;
            _dataControllerService = dataControllerService;
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
            _dataControllerService.SetUserData("", "", _scoringService.Score);
            _dataControllerService.WriteUserDataToJsonLocal();
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
