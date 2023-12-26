using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam
{
    public interface IDamageable
    {
        public void DoDamage(int damageValue);
        public void DoHeal(int healValue);
        public void DoDie();
    }
}
