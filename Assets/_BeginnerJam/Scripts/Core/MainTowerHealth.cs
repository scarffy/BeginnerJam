using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam
{
    using Core;

    public class MainTowerHealth : BaseHealth, IDamageable
    {
        public override void DoDie()
        {
            EventPipeline.OnGameEnd?.Invoke();
        }
    }
}
