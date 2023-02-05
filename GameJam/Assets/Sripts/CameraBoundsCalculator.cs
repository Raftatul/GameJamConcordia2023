using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsCalculator : MonoBehaviour
{
    private void FixedUpdate()
    {
        GlobalVariable.camBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
