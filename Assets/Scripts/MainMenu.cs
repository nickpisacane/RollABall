using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnGUI()
    {
        int w = Screen.width;
        int h = Screen.height;
        int y = (h - 50) / 2;
        int x = (w - 200) / 2;
        if (GUI.Button(new Rect(x, y, 200, 20), "Play"))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(x, y + 30, 200, 20), "Quit"))
        {
#if UNITY_EDITOR

#else
				Application.Quit();
#endif
        }
    }
}
