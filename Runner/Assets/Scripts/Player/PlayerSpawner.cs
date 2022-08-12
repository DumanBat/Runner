using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Player
{
    public class PlayerSpawner
    {
        readonly PlayerController.Factory _playerFactory;

        public PlayerSpawner(PlayerController.Factory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public PlayerController GetPlayer() => _playerFactory.Create();
    }
}
