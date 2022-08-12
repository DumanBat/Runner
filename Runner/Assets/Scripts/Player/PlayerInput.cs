using Eventyr.EndlessRunner.Scripts.Gameplay;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using Eventyr.EndlessRunner.Scripts.Utils;
using Eventyr.EndlessRunner.Scripts.Behaviours;
using System;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Player
{
    public class PlayerInput
    {
        private IInputService _inputService;
        public IInputService InputService => _inputService;

        public PlayerInput(GameConfig config, PlayerController playerController, IInputService inputService, ISideSwitch sideSwitch)
        {
            _inputService = inputService;

            sideSwitch.Init(config, playerController.Rigidbody);
            _inputService.OnSwipe += sideSwitch.SwitchSide;
        }
    }
}
