using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    void OnGUI()
    {

        if (GUI.Button(new Rect(Screen.width - 200 - 10, 10, 200, 20), "Exit"))
        {
            Application.LoadLevel(0);
        }

    }
}