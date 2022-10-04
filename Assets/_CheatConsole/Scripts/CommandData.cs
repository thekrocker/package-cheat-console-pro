using System;
using UnityEngine.Events;

[Serializable]
public class CommandData
{
    public string id;
    public string description;
    public string format;
    
    public UnityEvent OnInput;

    public void RaiseEvent() => OnInput?.Invoke();
}