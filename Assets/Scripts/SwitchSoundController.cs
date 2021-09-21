using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSoundController : MonoBehaviour
{
    [SerializeField]
    ScriptableSwitchEvents switchEvents;
    [SerializeField]
    AudioSource clickSource;

    Status actualStatus;
    bool firstTime = true;

    void Start()
    {
        actualStatus = Status.On;
        switchEvents.OnSwitchState += playSound;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void playSound(Status status)
    {
        if(firstTime)
        {
            actualStatus = Status.Off;
            clickSource.pitch = 1.1f;
            clickSource.Play();
            firstTime = false;
        }
        if(status == Status.On && actualStatus == Status.On)
        {
            actualStatus = Status.Off;
            clickSource.pitch = 1.1f;
            clickSource.Play();
        }
        else if (status == Status.Off && actualStatus == Status.Off)
        {
            actualStatus = Status.On;
            clickSource.pitch = 1f;
            clickSource.Play();
        }
        
    }
}
