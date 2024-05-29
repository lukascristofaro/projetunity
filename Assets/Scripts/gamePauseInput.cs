using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class GamePauseInput : MonoBehaviour
    {
       
        public bool pause;



#if ENABLE_INPUT_SYSTEM

        public void OnPause(InputValue value)
        {
            pause = value.isPressed;
        }
#endif



    }

}