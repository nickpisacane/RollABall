using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnGUI()
    {

        if (GUI.Button(new Rect(20, 20, 200, 20), "Exit"))
        {
            Application.LoadLevel(0);
        }

    }
}