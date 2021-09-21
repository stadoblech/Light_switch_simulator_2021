using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreen : MonoBehaviour
{

    public KeyCode key = KeyCode.F8;
    public int seqNumber =1;
    public int size = 1;
    public float delay = 2f;
    bool capture = false;
    int number;
    float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Debug.isDebugBuild) return;

        if (capture)
        {
            timer -= Time.deltaTime;
            if (timer<0)
            {
                string name = Application.persistentDataPath + "/screenshot_" + System.DateTime.Now.ToString().Replace('/', '_').Replace(':','_').Replace(' ','_') + ".png";
                ScreenCapture.CaptureScreenshot(name, size);
                Debug.Log("Screenshot saved: " + name);
                if (number<seqNumber)
                {
                    number++;
                    timer = delay;
                } else
                {
                    capture = false;
                }
            }
        }
        if (Input.GetKeyDown(key))
        {
            if (capture)
            {
                capture = false;
                return;
            }
            capture = true;
            number = 1;
            timer = delay;
        }
    }
}
