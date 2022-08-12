using Eventyr.EndlessRunner.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPlatform", menuName = "ScriptableObjects/Platform")]
    public class PlatformConfig : ScriptableObject
    {
        [SerializeField]
        private Mesh _mesh;
        [SerializeField]
        private Vector3 _localPosition;
        [SerializeField]
        private Vector3 _scale;
        [SerializeField]
        private Material _material;
        [SerializeField]
        private int _minObstacleAmount;
        [SerializeField]
        private int _maxObstacleAmount;
        [SerializeField]
        private List<ObstacleConfig> _obstacleConfigs;

        public Mesh Mesh => _mesh;
        public Vector3 LocalPosition => _localPosition;
        public Vector3 Scale => _scale;
        public Material Material => _material;
        public int MinObstacleAmount => _minObstacleAmount;
        public int MaxObstacleAmount => _maxObstacleAmount;
        public List<ObstacleConfig> ObstacleConfigs => _obstacleConfigs;
    }
}
