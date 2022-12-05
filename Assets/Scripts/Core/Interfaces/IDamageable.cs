using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Core.Interfaces
{ 
    public interface IDamageable
    {
        public bool IsAlive { get; set; }
        public int HealthPoints { get; }
        public void ApplyDamage(int damageValue);
    }
}
