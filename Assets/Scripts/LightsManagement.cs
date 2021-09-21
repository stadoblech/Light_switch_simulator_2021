using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManagement : MonoBehaviour
{
    [SerializeField]
    ScriptableSwitchEvents switchEvents;

    [SerializeField]
    Light bulbLight,switchLight;



    void Start()
    {
        switchEvents.OnSwitchState += changeLight;
        bulbLight.enabled = true;
        switchLight.enabled = false;
    }

    void changeLight(Status status)
    {
        bulbLight.enabled = status == Status.On;
        switchLight.enabled = status == Status.Off;
    }
}
