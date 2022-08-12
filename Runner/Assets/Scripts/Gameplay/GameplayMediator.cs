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
        private LevelGenerator.Factory _levelGenerationService;

        [Inject]
        private PlayerController.Factory _playerControllerFactory;

        [Inject]
        public void Construct(ICameraService cameraService, LevelGenerator.Factory levelGenerator)
        {
            _cameraService = cameraService;
            _levelGenerationService = levelGenerator;
        }

        private void Awake()
        {
            var player = _playerControllerFactory.Create();
            _cameraService.Init(player.transform);
            var levelGenerator = _levelGenerationService.Create();
            levelGenerator.Init(player.Rigidbody);
        }
    }
}
