using Application.App;
using Application.Levels;
using Application.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Game
{
    public class GameMediator : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _levelConfig;
        [SerializeField]
        private PlayerController _playerController;

        public void Start()
        {
            var player = Instantiate(_playerController, _levelConfig.SpawningPosition, Quaternion.identity);
            GameManager.Instance.CameraController.SetCamera(Camera.main, player.transform);
        }
    }
}
