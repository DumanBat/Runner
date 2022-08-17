using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Behaviours
{
    [RequireComponent(typeof(Collider))]
    public class PickupBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            var item = collider.transform.parent.GetComponent<IPickable>();

            if (item == null)
                return;

            item.Use();
        }
    }
}
