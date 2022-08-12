using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IMoveable
    {
        public Rigidbody Rigidbody { get; set; }
        public void Move(Vector3 position);
    }
}
