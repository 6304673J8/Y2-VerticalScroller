using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    public static float Horizontal
    {
        get { return Input.GetAxis("Horizontal"); }
    }
    public static bool Fire
    {
        get { return Input.GetKey(KeyCode.Space); }
    }
}