using Eventyr.EndlessRunner.Scripts.Gameplay;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using Eventyr.EndlessRunner.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;


namespace Eventyr.EndlessRunner.Scripts.Behaviours
{
    public class SwitchSideBehaviour : ISideSwitch
    {
        private Dictionary<TrackSide, Vector3> _trackSides;
        private Rigidbody _rigidbody;

        public TrackSide TrackSide { get; set; }

        public void Init(GameConfig config, Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            _trackSides = new Dictionary<TrackSide, Vector3>(3);
            _trackSides.Add(TrackSide.Left, config.LeftTrackPos);
            _trackSides.Add(TrackSide.Center, config.CenterTrackPos);
            _trackSides.Add(TrackSide.Right, config.RightTrackPos);

            TrackSide = TrackSide.Center;
        }

        public void SwitchSide(Direction direction)
        {
            var targetSide = GetTargetSide(direction);

            if (TrackSide == targetSide)
                return;

            if (targetSide == TrackSide.Center)
                _rigidbody.position = new Vector3(0, _rigidbody.position.y, _rigidbody.position.z);
            else
                _rigidbody.MovePosition(_rigidbody.position + _trackSides[targetSide]);

            TrackSide = targetSide;
        }

        private TrackSide GetTargetSide(Direction direction)
        {
            TrackSide targetSide;

            switch (TrackSide)
            {
                case TrackSide.Left:
                    targetSide = direction == Direction.Left
                        ? TrackSide.Left
                        : TrackSide.Center;
                    break;
                case TrackSide.Center:
                    targetSide = direction == Direction.Left
                        ? TrackSide.Left
                        : TrackSide.Right;
                    break;
                case TrackSide.Right:
                    targetSide = direction == Direction.Left
                        ? TrackSide.Center
                        : TrackSide.Right;
                    break;
                default:
                    targetSide = TrackSide.Center;
                    break;
            }

            return targetSide;
        }
    }
}
