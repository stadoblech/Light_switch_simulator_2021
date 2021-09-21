using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SwitchController : MonoBehaviour
{
    [SerializeField]
    ScriptableSwitchEvents switchEvents;

    [SerializeField]
    Transform switchObject;
    [SerializeField]
    float toggleTime;
    [SerializeField]
    float offRotationLocation;

    Status status;

    Quaternion defaultRotation;
    
    float currentRotationX;

    SwipeController swipe;
    
    public int Counter
    {
        get; private set;
    }

    
    void Start()
    {
        swipe = GetComponent<SwipeController>();
        swipe.OnSwipeAction += changeState;

        defaultRotation = switchObject.rotation;
        if(PlayerPrefs.HasKey("COUNTER"))
        {
            Counter = PlayerPrefs.GetInt("COUNTER");
        }
    }

    void changeState(SwipeDirection dir) //Status status)
    {
        Quaternion rot = switchObject.rotation;
        if (dir == SwipeDirection.Down && status == Status.Off)
        {
            Counter++;
            status = Status.On;
            rot = defaultRotation;
            PlayerPrefs.SetInt("COUNTER",Counter);
        }
        else if(dir == SwipeDirection.Up && status == Status.On)
        {
            status = Status.Off;
            rot *= Quaternion.Euler(offRotationLocation,0,0); 
        }

        switchEvents.OnSwitchState?.Invoke(status);
        switchObject.DORotateQuaternion(rot, toggleTime);
    }

    public void addRewardedCount()
    {
        Counter += 100;
        PlayerPrefs.SetInt("COUNTER", Counter);
    }
}
