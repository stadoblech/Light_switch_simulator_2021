using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableSwitchEvents : ScriptableObject
{
    public delegate void OnSwitchChangeStateDelegate(Status status);
    public OnSwitchChangeStateDelegate OnSwitchState;

}
