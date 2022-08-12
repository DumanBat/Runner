using Eventyr.EndlessRunner.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewObstacle", menuName = "ScriptableObjects/Obstacle")]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField]
        private Mesh _mesh;
        [SerializeField]
        private Vector3 _localPosition;
        [SerializeField]
        private Vector3 _scale;
        [SerializeField]
        private Material _material;

        public Mesh Mesh => _mesh;
        public Vector3 LocalPosition => _localPosition;
        public Vector3 Scale => _scale;
        public Material Material => _material;
    }
}
