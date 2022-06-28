using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application.Levels
{
    [CreateAssetMenu(fileName = "NewLevelConfig", menuName = "Levels/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField]
        private Vector3 _spawningPosition;

        public Vector3 SpawningPosition => _spawningPosition;
    }
}
