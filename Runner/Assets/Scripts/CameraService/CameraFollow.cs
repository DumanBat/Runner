using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eventyr.EndlessRunner.Scripts.Interfaces;

namespace Eventyr.EndlessRunner.Scripts.CameraService
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow : MonoBehaviour, ICameraService
    {
        [SerializeField]
        private float lerpSpeed;

        private Transform target;
        private Vector3 offset;
        private Vector3 targetPos;

        public void Init(Transform followTarget)
        {
            target = followTarget;
            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
    }
}
