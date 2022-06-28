using UnityEngine;

namespace Application.App.CameraControls
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float lerpSpeed;

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
