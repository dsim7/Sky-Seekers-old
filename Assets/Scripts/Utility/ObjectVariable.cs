using System;
using UnityEngine;
using UnityEngine.Events;


public class ObjectVariable<T> : ScriptableObject
{
    private T _value;
    public T Value { get { return _value; } set { _value = value; _onChange.Invoke(); } }

    [SerializeField]
    private UnityEvent _onChange = new UnityEvent();
    
    public void RegisterAction(UnityAction action)
    {
        _onChange.AddListener(action);
    }

    public void UnregisterAction(UnityAction action)
    {
        _onChange.RemoveListener(action);
    }
}



