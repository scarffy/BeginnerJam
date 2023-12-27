using UnityEngine;

namespace BeginnerJam.Audios
{
    public class AudioManager : MonoBehaviour
    {
        #region  Singleton
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<AudioManager>();

                return _instance;
            }
        }
        private static AudioManager _instance;
        #endregion
        
        
    }
}