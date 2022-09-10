using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.Utils;
using System;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Player
{
    public class DesktopInput : MonoBehaviour, IInputService
    {
        private Action<Direction> Swiped;
        public Action<Direction> OnSwipe
        {
            get => Swiped;
            set => Swiped = value;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                Swiped?.Invoke(Direction.Left);
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                Swiped?.Invoke(Direction.Right);
        }
    }
}
