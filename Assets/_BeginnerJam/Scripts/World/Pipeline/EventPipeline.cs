using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam
{
    public static class EventPipeline
    {
        //! Game flow event
        public static Action OnPreGameStart;
        public static Action OnGameStart;
        public static Action OnWaveStart;
        public static Action OnWaveEnd;
        public static Action OnGameEnd;
        public static Action OnGameRestart;

        //! Consolidate one update function
        public static Action UpdateEvent;
    }
}
