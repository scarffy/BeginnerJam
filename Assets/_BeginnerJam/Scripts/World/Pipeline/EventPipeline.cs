using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam
{
    /// <summary>
    /// Game flow events
    /// </summary>
    public static class EventPipeline
    {
        /// <summary>
        /// Events before start getting game map
        /// </summary>
        public static Action OnPreGameStart;
        
        /// <summary>
        /// 
        /// </summary>
        public static Action OnGameStart;

        /// <summary>
        /// Events for counting down wave
        /// </summary>
        public static Action OnPreWaveStart;
        
        /// <summary>
        /// Events when wave start
        /// </summary>
        public static Action OnWaveStart;
        
        /// <summary>
        /// Events when wave end
        /// </summary>
        public static Action OnWaveEnd;
        
        /// <summary>
        /// Events when game end
        /// </summary>
        public static Action OnGameEnd;
        
        /// <summary>
        /// Events when user restart game
        /// </summary>
        public static Action OnGameRestart;

        /// <summary>
        /// Consolidate one update function
        /// </summary>
        public static Action UpdateEvent;
    }
}
