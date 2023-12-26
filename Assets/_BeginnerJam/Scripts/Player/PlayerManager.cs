using System.Collections;
using System.Collections.Generic;
using BeginnerJam.Manager.Input;
using UnityEngine;

namespace BeginnerJam.Player
{
    public class PlayerManager : MonoBehaviour
    {
        
        
        

        public void Movement()
        {
            //! We can't do our movement input
            if(InputManager.Instance.inputState == InputManager.InputState.UIOnly)
                return;
            
            
        }
    }
}
