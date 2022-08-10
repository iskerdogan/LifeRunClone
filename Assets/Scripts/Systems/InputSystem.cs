using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class InputSystem : Singleton<InputSystem>
{
    public event Action<Touch> TouchPositionChanged;

    private void FixedUpdate() 
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            TouchPositionChanged?.Invoke(touch);
        }  
    }
}
