using System;
using UnityEngine.Events;

[Serializable]
public class CommandData
{
    public string id;
    public string description;
    public string format;
    
    public UnityEvent OnInput;
    public Action OnInputAction;

    public void RaiseUnityEvent() => OnInput?.Invoke();
    public void RaiseAction() => OnInputAction?.Invoke();
}