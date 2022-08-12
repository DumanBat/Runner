using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class Obstacle : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<ObstacleConfig, Obstacle>
        {
            protected override void Reinitialize(ObstacleConfig config, Obstacle obstacle)
            {
                obstacle._meshFilter.mesh = config.Mesh;
                obstacle._meshRenderer.sharedMaterial = config.Material;
                obstacle._model.localScale = config.Scale;
                obstacle._model.localPosition = config.LocalPosition;
            }
        }

        [SerializeField]
        private Transform _model;
        [SerializeField]
        private MeshFilter _meshFilter;
        [SerializeField]
        private MeshRenderer _meshRenderer;
    }
}
