using UnityEngine;
using UnityEngine.Pool;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class GenericObjectPool<T> where T: Component
    {
        public ObjectPool<T> GetObjectPool(T objectPrefab)
        {
            var objectPool = new ObjectPool<T>(
                () => InstantiatePoolObject(objectPrefab),
                GetPoolObject,
                ReleasePoolObject,
                GameObject.Destroy,
                false, 10, 10);

            return objectPool;
        }

        private T InstantiatePoolObject(T objectPrefab) => GameObject.Instantiate(objectPrefab);

        private void GetPoolObject(T poolObject)
        {
            poolObject.gameObject.SetActive(true);
        }

        private void ReleasePoolObject(T poolObject)
        {
            poolObject.gameObject.SetActive(false);
            poolObject.transform.position = Vector3.zero;
        }
    }
}