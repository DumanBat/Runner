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
        private ISideSwitch _sideSwitch;
        private IInputService _inputService;
        private PlayerInput _playerInput;
        private Rigidbody _rb;

        public TrackSide CurrentTrackSide { get; set; }
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
            _rb = GetComponent<Rigidbody>();

            _playerInput = new PlayerInput(_config, this, _inputService, _sideSwitch);
        }

        private void Start()
        {
            Init(_config);
        }

        public void Init(GameConfig config)
        {
            PlayerSpeed = config.PlayerSpeed;

            _moveable.Rigidbody = _rb;
        }

        private void Update()
        {
            var position = new Vector3(0, 0, 1);
            _moveable.Move(position * Time.deltaTime * PlayerSpeed);
        }
    }
}