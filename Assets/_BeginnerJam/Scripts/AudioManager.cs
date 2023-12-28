using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.Manager
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

        [Header("Settings")] 
        [SerializeField] private AudioSource _audioBGMSource;
        [SerializeField] private AudioSource _audioSFXSource;
        
        [Header("Assets Settings")]
        [SerializeField] private AudioClip _bgmClip;

        [SerializeField] private AudioClip _clickClip;
        [SerializeField] private AudioClip _cancelClip;
        [SerializeField] private AudioClip _openClip;
        
        public void Initialize()
        {
            PlayBackgroundMusic();
            Debug.Log($"[AudioManager]: Initialized");   
        }

        public void PlayBackgroundMusic()
        {
            
        }

        public void PlaySFX(SFXType sfxType)
        {
            switch (sfxType)
            {
                case SFXType.none:
                    break;
                
                case SFXType.open:
                    
                    break;
            }
        }
        
        public enum  SFXType
        {
            none,
            click,
            cancel,
            open
        }
    }
}
