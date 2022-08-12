using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewGameConfig", menuName = "ScriptableObjects/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField]
        private float _playerSpeed;
        [SerializeField]
        private Vector3 _leftTrackPos;
        [SerializeField]
        private Vector3 _centerTrackPos;
        [SerializeField]
        private Vector3 _rightTrackPos;

        public float PlayerSpeed => _playerSpeed;
        public Vector3 LeftTrackPos => _leftTrackPos;
        public Vector3 CenterTrackPos => _centerTrackPos;
        public Vector3 RightTrackPos => _rightTrackPos;
    }
}
