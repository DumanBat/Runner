using UnityEngine;
using Eventyr.EndlessRunner.Scripts.Interfaces;

namespace Eventyr.EndlessRunner.Scripts.Behaviours
{
    public class MovementBehaviour : MonoBehaviour, IMoveable
    {
        public Rigidbody Rigidbody { get; set; }

        public void Move(Vector3 position)
        {
            Rigidbody.MovePosition(Rigidbody.position + position);
        }
    }
}
