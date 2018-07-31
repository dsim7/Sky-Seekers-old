using System;
using UnityEngine;


public abstract class ActionEffector<T> : ScriptableObject
{
    public abstract void Effect(T instance);
}


