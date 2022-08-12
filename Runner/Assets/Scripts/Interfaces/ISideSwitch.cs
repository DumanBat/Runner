using Eventyr.EndlessRunner.Scripts.Gameplay;
using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using Eventyr.EndlessRunner.Scripts.Utils;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface ISideSwitch
    {
        public TrackSide TrackSide { get; set; }
        public void Init(GameConfig config, Rigidbody rigidbody);
        public void SwitchSide(Direction direction);
    }
}
