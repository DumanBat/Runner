using Eventyr.EndlessRunner.Scripts.Gameplay;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<PlayerController>
        {
        }

        private GameConfig _config;

        private IMoveable _moveable;
        private IHealth _health;
        private ISideSwitch _sideSwitch;
        private IInputService _inputService;
        private PlayerInput _playerInput;
        private Rigidbody _rb;

        private bool _isActive;

        public TrackSide CurrentTrackSide { get; set; }
        public IHealth Health => _health;
        private float PlayerSpeed { get; set; }
        public Rigidbody Rigidbody => _rb;

        [Inject]
        public void Construct(GameConfig config, IInputService inputService, ISideSwitch sideSwitch)
        {
            _config = config;
            _inputService = inputService;
            _sideSwitch = sideSwitch;
        }

        private void Awake()
        {
            _moveable = GetComponent<IMoveable>();
            _health = GetComponent<IHealth>();
            _rb = GetComponent<Rigidbody>();

            _playerInput = new PlayerInput(_config, this, _inputService, _sideSwitch);
            _health.Died += Stop;
        }

        private void Update()
        {
            if (!_isActive)
                return;

            var position = new Vector3(0, 0, 1);
            _moveable.Move(position * Time.deltaTime * PlayerSpeed);
        }

        public void Init()
        {
            PlayerSpeed = _config.PlayerSpeed;
            _health.Init(_config.PlayerHealth);
            _moveable.Rigidbody = _rb;

            _isActive = true;
        }

        private void Stop()
        {
            _isActive = false;
        }
    }
}