using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Core
{
    public class EnemyHealth : BaseHealth, IDamageable
    {
        public override void DoDie()
        {
            gameObject.SetActive(false);
        }
    }
}
