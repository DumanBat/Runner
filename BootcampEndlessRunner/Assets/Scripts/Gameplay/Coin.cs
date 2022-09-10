using Eventyr.EndlessRunner.Scripts.Gameplay;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class Coin : MonoBehaviour, IPickable
    {
        public class Pool : MonoMemoryPool<Coin>
        {
            protected override void Reinitialize(Coin coin)
            {
            }
        }

        public IPickable.Pickup PickedUp { get; set; }
        public CoinsGenerator OriginGenerator { get; set; }

        [Inject]
        private Coin.Pool _coinPool;

        public void Use()
        {
            PickedUp?.Invoke();
            OriginGenerator.SpawnedCoins.Remove(this);
            Unload();
        }

        public void Unload()
        {
            OriginGenerator = null;
            PickedUp = null;
            _coinPool.Despawn(this);
        }
    }
}
