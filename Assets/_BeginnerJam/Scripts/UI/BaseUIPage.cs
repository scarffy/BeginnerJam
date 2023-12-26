using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeginnerJam.UI
{
    public class BaseUIPage : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public virtual void Initialized()
        {
            if (_canvasGroup == null)
                _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void OpenPage()
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
            _canvasGroup.alpha = 1;
            StartCoroutine(PlayAudioCoroutine(0f));
        }

        public virtual void ClosePage()
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 0;
            
            StartCoroutine(PlayAudioCoroutine(.7f));
        }

        public IEnumerator PlayAudioCoroutine(float fValue)
        {
            yield return new WaitForSeconds(fValue);
            PlayAudioSX();
        }

        public virtual void PlayAudioSX()
        {
            
        }
    }
}
