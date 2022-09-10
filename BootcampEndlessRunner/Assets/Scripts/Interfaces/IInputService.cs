using Eventyr.EndlessRunner.Scripts.Utils;
using System;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IInputService
    {
        public Action<Direction> OnSwipe { get; set; }
    }
}
