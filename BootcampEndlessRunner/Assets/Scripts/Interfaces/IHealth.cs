using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IHealth
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public delegate void Die();
        public Die Died { get; set; }

        public void Init(int maxHealth);

        public void TakeDamage(int damage);
    }
}
