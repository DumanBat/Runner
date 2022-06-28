using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Modules.Utils;
using Application.App.CameraControls;
using Application.Game;

namespace Application.App
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private CameraController _cameraController;
        [SerializeField]
        private GameMediator _gameMediator;

        public CameraController CameraController => _cameraController;
        public GameMediator GameMediator => _gameMediator;
    }
}
