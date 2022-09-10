using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Behaviours
{
    public class HealthBehaviour : MonoBehaviour, IHealth
    {
        private int _health;
        public int Health
        {
            get => _health;
            set
            {
                if (value >= MaxHealth)
                    _health = MaxHealth;
                else
                    _health = value <= 0 ? 0 : value;
            }
        }
        public int MaxHealth { get; set; }
        public IHealth.Die Died { get; set; }

        public void Init(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health == 0)
                Died?.Invoke();
        }
    }
}
